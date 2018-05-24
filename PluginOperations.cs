using System;
using LSOne.Controls;
using LSOne.DataLayer.BusinessObjects;
using LSOne.ViewCore.Controls;
using LSOne.ViewCore.EventArguments;
using LSOne.ViewPlugins.ExtendedWarranty.ViewPages;

namespace LSOne.ViewPlugins.ExtendedWarranty
{
    internal class PluginOperations
    {
        public static void ShowHelloWorldView(object sender, EventArgs args)
        {
            PluginEntry.Framework.ViewController.Add(new Views.HelloWorldView());
        }

        public static void ShowSimpleView(object sender, EventArgs args)
        {
            PluginEntry.Framework.ViewController.Add(new Views.SimpleView());
        }

        public static void ShowSingleListView(object sender, EventArgs args)
        {
            PluginEntry.Framework.ViewController.Add(new Views.SingleListView());
        }

        public static void ShowDoubleListView(object sender, EventArgs args)
        {
            PluginEntry.Framework.ViewController.Add(new Views.DoubleListView());
        }

        public static void TaskBarItemCallback(object sender, ContextBarItemConstructionArguments arguments)
        {
            
        }


        internal static void AddOperationCategoryHandler(object sender, OperationCategoryArguments args)
        {

        }

        internal static void AddOperationItemHandler(object sender, OperationItemArguments args)
        {

        }

        internal static void AddOperationButtonHandler(object sender, OperationButtonArguments args)
        {

        }

        internal static void ConstructTabs(object sender, TabPanelConstructionArguments args)
        {

        }
    }
}
