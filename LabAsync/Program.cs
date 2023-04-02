namespace LabAsync
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var cTs = new CancellationTokenSource();
      cTs.Cancel();

      var task = TestAsync(cTs.Token, 5000);

      Console.WriteLine($"ErrorCode: {await task}");
    }

    static async Task<int> TestAsync(CancellationToken token, int delay)
    {       
      while (true)
      {        
        Thread.Sleep(delay);
        if(token.IsCancellationRequested)
        {
          break;
        }
      }

      return 299;
    }
  }
}