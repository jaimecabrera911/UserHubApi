namespace UserHub.Dto
{
    public  class ApiResponse
    {

        public required int Status { get; set; }

        public required object Data { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
