﻿#pragma warning disable CS8618
using System.Runtime.Serialization;

namespace IIS_0102_XSD_RNG.Models
{
    [DataContract]
    public class FreeNewsModel
    {
        public FreeNewsModel()
        {

        }

        public FreeNewsModel(string title, string author, string publishedDate, string publishedDatePrecision, string link, string cleanUrl, string summary, string rights, int rank, string topic, string country, string language, List<string> authors, string media, bool isOpinion, string twitterAccount, double score, string id)
        {
            Title = title;
            Author = author;
            PublishedDate = publishedDate;
            PublishedDatePrecision = publishedDatePrecision;
            Link = link;
            CleanUrl = cleanUrl;
            Summary = summary;
            Rights = rights;
            Rank = rank;
            Topic = topic;
            Country = country;
            Language = language;
            Authors = authors;
            Media = media;
            IsOpinion = isOpinion;
            TwitterAccount = twitterAccount;
            Score = score;
            Id = id;
        }

        [DataMember(Order = 0)]
        public string Title { get; set; }

        [DataMember(Order = 1)]
        public string Author { get; set; }

        [DataMember(Order = 2)]
        public string PublishedDate { get; set; }

        [DataMember(Order = 3)]
        public string PublishedDatePrecision { get; set; }

        [DataMember(Order = 4)]
        public string Link { get; set; }

        [DataMember(Order = 5)]
        public string CleanUrl { get; set; }

        [DataMember(Order = 6)]
        public string Summary { get; set; }

        [DataMember(Order = 7)]
        public string Rights { get; set; }

        [DataMember(Order = 8)]
        public int Rank { get; set; }

        [DataMember(Order = 9)]
        public string Topic { get; set; }

        [DataMember(Order = 10)]
        public string Country { get; set; }

        [DataMember(Order = 11)]
        public string Language { get; set; }

        [DataMember(Order = 12)]
        public List<string> Authors { get; set; }

        [DataMember(Order = 13)]
        public string Media { get; set; }

        [DataMember(Order = 14)]
        public bool IsOpinion { get; set; }

        [DataMember(Order = 15)]
        public string TwitterAccount { get; set; }

        [DataMember(Order = 16)]
        public double Score { get; set; }

        [DataMember(Order = 17)]
        public string Id { get; set; }
    
    }
}
