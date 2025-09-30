using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? Isbn { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    public string? Status { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
