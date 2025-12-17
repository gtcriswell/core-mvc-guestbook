namespace Domain.Dtos
{
    public record GuestbookDto
    {
        public int GuestId { get; init; }

        public string? EmailAddress { get; init; }

        public string? Comment { get; init; }

        public DateTime? CreatedDate { get; init; }
    }
}
