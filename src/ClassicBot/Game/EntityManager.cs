using ClassicBot.Statics;
using Process.NET;
using System.Threading.Tasks;

namespace ClassicBot.Game
{
    public sealed class EntityManager
    {
        readonly ProcessSharp processSharp;

        public EntityManager(ProcessSharp processSharp)
        {
            this.processSharp = processSharp;
        }

        public void Run()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 1.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 2.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 3.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 4.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 5.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 4.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 3.0f);
                    await Task.Delay(500);
                    processSharp.Memory.Write(Offsets.LocalPlayer.Scale, 2.0f);
                    await Task.Delay(500);
                }
            });
        }
    }
}
