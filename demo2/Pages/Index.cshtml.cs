using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel: PageModel
{
    public DateTime CurrentTime => DateTime.UtcNow;
}