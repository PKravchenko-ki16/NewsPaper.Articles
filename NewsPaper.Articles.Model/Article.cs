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

        [Column("article_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 50)]
        [Column("description")]
        public string Description { get; set; }

        [Column("picture")]
        public string Picture { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 500)]
        [Column("text")]
        public string Text { get; set; }

        [Required]
        [Column("nike_name_author")]
        public string NikeNameAuthor { get; set; }

        [Required]
        [Column("author_guid")]
        public Guid AuthorGuid { get; set; }

        [Required]
        [Column("editor_guid")]
        public Guid EditorGuid { get; set; }

        [Column("is_archive")]
        public bool IsArchive { get; set; }

        [Column("is_revision")]
        public bool IsRevision { get; set; }

        [Required]
        [Column("date_of_writing")]
        public DateTime DateOfWriting { get; set; }

        [Column("date_of_revision")]
        public DateTime DateOfRevision { get; set; }
    }
}