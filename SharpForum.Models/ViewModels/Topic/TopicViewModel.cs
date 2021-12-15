﻿namespace SharpForum.Models.ViewModels.Topic
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TopicViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsSticky { get; set; }

        public bool IsLocked { get; set; }

        public DateTime PublishDate { get; set; }

        // Custom view properties

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }

        public int RepliesCount { get; set; }
    }
}