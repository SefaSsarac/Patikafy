using System;
using System.Collections.Generic;
using System.Linq;

public class Singer
{
    public string Name { get; set; }
    public string MusicGenre { get; set; }
    public int DebutYear { get; set; }
    public int AlbumSales { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Verileri nesnelere dönüştürme
        List<Singer> singers = new List<Singer>
        {
            new Singer { Name = "Ajda Pekkan", MusicGenre = "Pop", DebutYear = 1968, AlbumSales = 20 },
            new Singer { Name = "Sezen Aksu", MusicGenre = "Türk Halk Müziği / Pop", DebutYear = 1971, AlbumSales = 10 },
            new Singer { Name = "Funda Arar", MusicGenre = "Pop", DebutYear = 1999, AlbumSales = 3 },
            new Singer { Name = "Sertab Erener", MusicGenre = "Pop", DebutYear = 1994, AlbumSales = 5 },
            new Singer { Name = "Sıla", MusicGenre = "Pop", DebutYear = 2009, AlbumSales = 3 },
            new Singer { Name = "Serdar Ortaç", MusicGenre = "Pop", DebutYear = 1994, AlbumSales = 10 },
            new Singer { Name = "Tarkan", MusicGenre = "Pop", DebutYear = 1992, AlbumSales = 40 },
            new Singer { Name = "Hande Yener", MusicGenre = "Pop", DebutYear = 1999, AlbumSales = 7 },
            new Singer { Name = "Hadise", MusicGenre = "Pop", DebutYear = 2005, AlbumSales = 5 },
            new Singer { Name = "Gülben Ergen", MusicGenre = "Pop / Türk Halk Müziği", DebutYear = 1997, AlbumSales = 10 },
            new Singer { Name = "Neşet Ertaş", MusicGenre = "Türk Halk Müziği / Türk Sanat Müziği", DebutYear = 1960, AlbumSales = 2 },
        };

        // Sorgular
        // Adı 'S' ile başlayan şarkıcılar
        Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
        var singersStartingWithS = singers.Where(s => s.Name.StartsWith("S"));
        foreach (var singer in singersStartingWithS)
        {
            Console.WriteLine(singer.Name);
        }

        //Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
        Console.WriteLine("\nAlbüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
        var singersWithHighSales = singers.Where(s => s.AlbumSales > 10);
        foreach (var singer in singersWithHighSales)
        {
            Console.WriteLine($"{singer.Name} - {singer.AlbumSales} milyon");
        }

        //2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar (Çıkış yılına göre gruplanmış)
        Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar (Çıkış yılına göre gruplanmış):");
        var popSingersBefore2000 = singers
            .Where(s => s.MusicGenre == "Pop" && s.DebutYear < 2000)
            .GroupBy(s => s.DebutYear)
            .OrderBy(g => g.Key);
        foreach (var group in popSingersBefore2000)
        {
            Console.WriteLine($"{group.Key} yılında çıkış yapanlar:");
            foreach (var singer in group)
            {
                Console.WriteLine(singer.Name);
            }
        }

        // En çok albüm satan şarkıcı
        var bestSellingSinger = singers.OrderByDescending(s => s.AlbumSales).First();
        Console.WriteLine($"\nEn çok albüm satan şarkıcı: {bestSellingSinger.Name} ({bestSellingSinger.AlbumSales} milyon)");

        // En yeni ve en eski çıkış yapan şarkıcı
        var newestSinger = singers.OrderByDescending(s => s.DebutYear).First();
        var oldestSinger = singers.OrderBy(s => s.DebutYear).First();
        Console.WriteLine($"En yeni çıkış yapan şarkıcı: {newestSinger.Name} ({newestSinger.DebutYear})");
        Console.WriteLine($"En eski çıkış yapan şarkıcı: {oldestSinger.Name} ({oldestSinger.DebutYear})");
    }
}