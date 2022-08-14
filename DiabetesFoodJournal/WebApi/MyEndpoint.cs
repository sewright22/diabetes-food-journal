namespace WebApi
{
    public class MyEndpoint : Endpoint<MyRequest>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(MyRequest req, CancellationToken ct)
        {
            var response = new MyResponse()
            {
                FullName = req.FirstName + " " + req.LastName,
                IsOver18 = req.Age > 18
            };

            await SendAsync(response);
        }
    }
}
