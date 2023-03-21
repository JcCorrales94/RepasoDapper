using System;
using System.Collections.Generic;

namespace _64.DatabaseFirst.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int PublishedYear { get; set; }

    public int Sales { get; set; }

    public virtual Author Author { get; set; } = null!;
}
