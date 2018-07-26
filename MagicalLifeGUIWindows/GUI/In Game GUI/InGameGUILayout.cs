﻿using MagicalLifeSettings.Storage;

namespace MagicalLifeGUIWindows.GUI.In_Game_GUI
{
    /// <summary>
    /// Returns the correct hardcoded values for the current screen resolution for the new world menu.
    /// </summary>
    public static class InGameGUILayout
    {
        /// <summary>
        /// The x position at which the in game GUI container is drawn.
        /// </summary>
        public static int ContainerX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerX;

                    default:
                        return InGameGUILayout1920x1080.ContainerX;
                }
            }
        }

        /// <summary>
        /// The y position at which the in game GUI container is drawn.
        /// </summary>
        public static int ContainerY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerY;

                    default:
                        return InGameGUILayout1920x1080.ContainerY;
                }
            }
        }

        /// <summary>
        /// The width of the in game GUI container.
        /// </summary>
        public static int ContainerWidth
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerWidth;

                    default:
                        return InGameGUILayout1920x1080.ContainerWidth;
                }
            }
        }

        /// <summary>
        /// The height of the in game GUI container.
        /// </summary>
        public static int ContainerHeight
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ContainerHeight;

                    default:
                        return InGameGUILayout1920x1080.ContainerHeight;
                }
            }
        }

        /// <summary>
        /// The Y position at which to render the top of every action button.
        /// </summary>
        public static int ActionButtonY
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ActionButtonY;

                    default:
                        return InGameGUILayout1920x1080.ActionButtonY;
                }
            }
        }

        /// <summary>
        /// The size of each action button.
        /// </summary>
        public static int ActionButtonSize
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.ActionButtonSize;

                    default:
                        return InGameGUILayout1920x1080.ActionButtonSize;
                }
            }
        }

        /// <summary>
        /// The x position at which to render the mining action button.
        /// </summary>
        public static int MineActionButtonX
        {
            get
            {
                switch ((Resolution)MainWindow.Default.Resolution)
                {
                    case Resolution._1920x1080:
                        return InGameGUILayout1920x1080.MineActionButtonX;

                    default:
                        return InGameGUILayout1920x1080.MineActionButtonX;
                }
            }
        }
    }
}