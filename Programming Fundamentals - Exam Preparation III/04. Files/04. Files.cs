using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class File
    {
        public string Root { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
    }

class Files
{
    static void Main()
    {

        var n = int.Parse(Console.ReadLine());
        var allFiles = new List<File>();
        for (int i = 0; i < n; i++)
        {
            var inputLine = Console.ReadLine();
            string root = ExtractRoot(inputLine);

            var mostRightSemicolonIndex = inputLine.LastIndexOf(";");
            long size = 0;
            if (mostRightSemicolonIndex >= 0)
            {
                size = long.Parse(inputLine.Substring(mostRightSemicolonIndex + 1));
                var pathPlusName = inputLine.Substring(0, mostRightSemicolonIndex);

                var ext = ExtractExtension(pathPlusName);
                var fileName = ExtractFileName(pathPlusName);

                var match = allFiles.FirstOrDefault(
                    f => f.FileName == fileName &&
                    f.Root == root);
                if (match != null)
                {
                    match.Size = size;
                }
                else
                {
                    var file = new File()
                    {
                        Root = root,
                        FileName = fileName,
                        Extension = ext,
                        Size = size
                    };
                    allFiles.Add(file);
                }
            }
        }

        var query = Regex.Split(Console.ReadLine(), @"\s+in\s+");
        var extQuery = query[0];
        var rootQuery = query[1];

        var resultFiles = allFiles
            .Where(f => f.Root == rootQuery)
            .Where(f => f.Extension == extQuery)
            .OrderByDescending(f => f.Size)
            .ThenBy(f => f.FileName);

        if (resultFiles.Any())
        {
            foreach (var f in resultFiles)
            {
                Console.WriteLine($"{f.FileName} - {f.Size} KB ");
            }
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    static string ExtractExtension(string pathPlusName)
    {
        var mostRightDotIndex = pathPlusName.LastIndexOf(@".");
        string ext = "";
        if (mostRightDotIndex >= 0)
        {
            ext = pathPlusName.Substring(mostRightDotIndex + 1);
        }
        return ext;
    }

    static string ExtractRoot(string inputLine)
    {
        var mostLeftSlashIndex = inputLine.IndexOf(@"\");
        string root = "";
        if (mostLeftSlashIndex >= 0)
        {
            root = inputLine.Substring(0, mostLeftSlashIndex);
        }
        return root;
    }

    static string ExtractFileName(string pathPlusName)
    {
        var mostRightSlashIndex = pathPlusName.LastIndexOf(@"\");
        string fileName = "";
        if (mostRightSlashIndex >= 0)
        {
            fileName = pathPlusName.Substring(mostRightSlashIndex + 1);
        }
        return fileName;
    }
}
