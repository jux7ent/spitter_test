using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public static class InternetChecker {
    private static string _checkingURL = "http://google.com";

    public static bool InternetIsAvailable() {
        string htmlText = GetHtmlFromUri(_checkingURL);

        // if doesn't contain, maybe redirecting(hotel, airport, etc)
        return htmlText.Contains("schema.org/WebPage");
    }

    private static string GetHtmlFromUri(string resource) {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse()) {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess) {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream())) {
                        //We are limiting the array to 80 so we don't have
                        //to parse the entire html document feel free to 
                        //adjust (probably stay under 300)
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs) {
                            html += ch;
                        }
                    }
                }
            }
        } catch {
            return "";
        }

        return html;
    }
}