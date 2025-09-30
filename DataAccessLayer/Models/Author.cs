using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public int? BirthYear { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
