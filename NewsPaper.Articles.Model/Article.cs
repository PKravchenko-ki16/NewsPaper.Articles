using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewsPaper.Articles.Models.Interfaces;

namespace NewsPaper.Articles.Models
{
    [Table("Article")]
    public class Article : DomainObject
    {
        public Article() {}

        public Article(Guid id)
        {
            Id = id;
        }

        public Article(Guid id, string title, string description, string text, string nikeNameAuthor, Guid authorGuid, Guid editorGuid, DateTime dateOfWriting)
        {
            Id = id;
            Title = title;
            Description = description;
            Text = text;
            NikeNameAuthor = nikeNameAuthor;
            AuthorGuid = authorGuid;
            EditorGuid = editorGuid;
            DateOfWriting = dateOfWriting;
            Rating = 0;
        }

        [Column("Id")]
        public override Guid Id { get; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [Column("Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        [Column("Description")]
        public string Description { get; set; }

        [Column("Picture")]
        public string Picture { get; set; }

        [Column("Rating")]
        public int Rating { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 500)]
        [Column("Text")]
        public string Text { get; set; }

        [Required]
        [Column("Nike_Name_Author")]
        public string NikeNameAuthor { get; set; }

        [Required]
        [Column("Author_Guid")]
        public Guid AuthorGuid { get; set; }

        [Required]
        [Column("Editor_Guid")]
        public Guid EditorGuid { get; set; }

        [Column("Is_Archive")]
        public bool IsArchive { get; set; }

        [Column("Is_Revision")]
        public bool IsRevision { get; set; }

        [Required]
        [Column("Date_Of_Writing")]
        public DateTime DateOfWriting { get; set; }

        [Column("Date_Of_Revision")]
        public DateTime DateOfRevision { get; set; }
    }
}