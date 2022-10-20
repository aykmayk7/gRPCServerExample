using Grpc.Core;
using gRPCExample;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static gRPCExample.Message;

namespace gRPCServerExample
{
    public class MessageService : MessageBase
    {
        public override async Task GetMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"Mesaj al�nm��t�r.");
            Console.WriteLine("Gelen mesaj : ");
            Console.WriteLine(request.Message);

            await Task.Run(async () =>
            {
                int count = 0;
                while (++count <= 10)
                {
                    await responseStream.WriteAsync(new MessageResponse { Message = $"G�nderilen mesaj {count}" });
                    await Task.Delay(1000);
                }
            });
        }
    }
}
