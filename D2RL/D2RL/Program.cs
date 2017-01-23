using SadConsole.Consoles;
using System;
using System.Collections.Generic;

using SadConsole;
using Microsoft.Xna.Framework;
using SadConsole.Input;
using D2RL.Consoles;

namespace D2RL
{
    class Program
    {
        //private static Windows.CharacterViewer _characterWindow;
        private static int currentConsoleIndex;
        public static List<string> consoleNames;
        private static int startingConsoleIndex = 0;
        private static int consoleWidth = 80;
        private static int consoleHeight = 50;

        static void Main(string[] args)
        {
            consoleNames = new List<string>();

            // Setup the engine and creat the main window.
            SadConsole.Engine.Initialize("Assets/Fonts/C64.font", consoleWidth, consoleHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Engine.EngineStart += Engine_EngineStart;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Engine.EngineUpdated += Engine_EngineUpdated;

            SadConsole.Engine.EngineDrawFrame += Engine_EngineDrawFrame;

            // Start the game.
            SadConsole.Engine.Run();

            
        }

        private static void Engine_EngineDrawFrame(object sender, EventArgs e)
        {
            // Custom drawing. You don't usually have to do this.
        }

        private static void Engine_EngineUpdated(object sender, EventArgs e)
        {
            //if (!_characterWindow.IsVisible)
            //{
            // This block of code cycles through the consoles in the SadConsole.Engine.ConsoleRenderStack, showing only a single console
            // at a time. This code is provided to support the custom consoles demo. If you want to enable the demo, uncomment one of the lines
            // in the Initialize method above.
            //if (SadConsole.Engine.Keyboard.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F1))
            //{
            //    MoveNextConsole();
            //}
            //else if (SadConsole.Engine.Keyboard.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F2))
            //{
            //    _characterWindow.Show(true);
            //}
            //else if (SadConsole.Engine.Keyboard.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F3))
            //{
            //}
            //}
        }

        private static void Engine_EngineStart(object sender, EventArgs e)
        {
            // Setup our custom theme.
            //Theme.SetupThemes();

            // By default SadConsole adds a blank ready-to-go console to the rendering system. 
            // We don't want to use that for the sample project so we'll remove it.
            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ActiveConsole = null;

#if DEBUG
            // We'll instead use our demo consoles that show various features of SadConsole.
            consoleNames.Add("Debug");
            consoleNames.Add("Main Menu");

            SadConsole.Engine.ConsoleRenderStack
                = new ConsoleList() {
                                        new Consoles.Debug.DebugConsole(consoleWidth, consoleHeight),
                                        new Consoles.MainMenu.MainMenuConsole(consoleWidth, consoleHeight)
                                    };
#else

#endif

            // Show the first console (by default all of our demo consoles are hidden)
            SadConsole.Engine.ConsoleRenderStack[startingConsoleIndex].IsVisible = true;

            // Set the first console in the console list as the "active" console. This allows the keyboard to be processed on the console.
            SadConsole.Engine.ActiveConsole = SadConsole.Engine.ConsoleRenderStack[startingConsoleIndex];
            currentConsoleIndex = startingConsoleIndex;

            //SadConsole.Engine.MonoGameInstance.Components.Add(new FPSCounterComponent(SadConsole.Engine.MonoGameInstance));
        }

        public static void MoveNextConsole()
        {
            currentConsoleIndex++;

            if (currentConsoleIndex >= SadConsole.Engine.ConsoleRenderStack.Count)
                currentConsoleIndex = 0;

            for (int i = 0; i < SadConsole.Engine.ConsoleRenderStack.Count; i++)
            {
                if (SadConsole.Engine.ConsoleRenderStack[i].GetType() == typeof(ConsoleList))
                {
                    foreach (SadConsole.Consoles.Console c in (ConsoleList)SadConsole.Engine.ConsoleRenderStack[i])
                    {
                        c.IsVisible = currentConsoleIndex == i;
                    }
                }
                SadConsole.Engine.ConsoleRenderStack[i].IsVisible = currentConsoleIndex == i;
            }

            Engine.ActiveConsole = SadConsole.Engine.ConsoleRenderStack[currentConsoleIndex];
        }

        public static void ActivateConsole(int index)
        {
            currentConsoleIndex = index;

            for (int i = 0; i < SadConsole.Engine.ConsoleRenderStack.Count; i++)
            {
                if (SadConsole.Engine.ConsoleRenderStack[i].GetType().BaseType == typeof(ConsoleList))
                {
                    foreach (SadConsole.Consoles.Console c in (ConsoleList)SadConsole.Engine.ConsoleRenderStack[i])
                    {
                        c.IsVisible = currentConsoleIndex == i;
                    }
                }
                SadConsole.Engine.ConsoleRenderStack[i].IsVisible = currentConsoleIndex == i;
            }
            

            Engine.ActiveConsole = SadConsole.Engine.ConsoleRenderStack[currentConsoleIndex];
            if(Engine.ActiveConsole is Consoles.BaseConsole)
            {
                BaseConsole c = (BaseConsole)Engine.ActiveConsole;
                c.Initialize();
            }

        }

    }

}