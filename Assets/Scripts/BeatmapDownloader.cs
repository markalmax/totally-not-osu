using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class BeatmapDownloader : MonoBehaviour
{
    public string OsuSessionCookie;
    public string setId;
    public async Task<string> DownloadAndUnpack(string setId)
    {
        string songsDirectory = Path.Combine(Application.persistentDataPath, "Songs");
        if (!Directory.Exists(songsDirectory)) 
        {
            Directory.CreateDirectory(songsDirectory);
        }

        string extractPath = Path.Combine(songsDirectory, setId);
        string tempOszPath = Path.Combine(songsDirectory, $"{setId}.osz");

        var cookieContainer = new CookieContainer();
        cookieContainer.Add(new System.Uri("https://osu.ppy.sh"), new Cookie("osu_session", OsuSessionCookie));
        
        using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
        using (var client = new HttpClient(handler))
        {
            client.DefaultRequestHeaders.Add("Referer", $"https://osu.ppy.sh/beatmapsets/{setId}");
            
            var response = await client.GetAsync($"https://osu.ppy.sh/beatmapsets/{setId}/download");
            response.EnsureSuccessStatusCode();

            using (var fs = new FileStream(tempOszPath, FileMode.Create))
            {
                await response.Content.CopyToAsync(fs);
            }
        }

        if (Directory.Exists(extractPath)) 
        {
            Directory.Delete(extractPath, true);
        }
        ZipFile.ExtractToDirectory(tempOszPath, extractPath);

        File.Delete(tempOszPath);

        Debug.Log($"Successfully unpacked beatmap to: {extractPath}");
        
        return extractPath; 
    }
}