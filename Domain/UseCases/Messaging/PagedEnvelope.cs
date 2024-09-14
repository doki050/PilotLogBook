namespace Domain.UseCases.Messaging;

public class PagedEnvelope<T> : Envelope<IEnumerable<T>>
{
    public PageDetails Paging { get; set; }

    public PagedEnvelope(IEnumerable<T> content, PageRequest request, int totalPages)
        : this(content, new PageDetails()
        {
            Page = request.Page,
            Limit = request.Limit,
            TotalPages = totalPages
        })
    { }

    public PagedEnvelope(IEnumerable<T> content, PageDetails paging)
        : base(content)
    {
        this.Paging = paging;
    }

    // For deserialization in API tests
    public PagedEnvelope() : base(null)
    { }
}
