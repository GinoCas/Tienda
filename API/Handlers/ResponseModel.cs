namespace API.Handlers
{
	public class APIResponse<T>
	{
		public List<T> Data { get; set; }
		public List<string> Errors { get; set; }

	}
}
