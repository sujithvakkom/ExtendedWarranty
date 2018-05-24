using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LSOne.Controls;
using LSOne.DataLayer.BusinessObjects;
using LSOne.DataLayer.BusinessObjects.Tax;
using LSOne.DataLayer.DataProviders;
using LSOne.DataLayer.DataProviders.Statements;
using LSOne.DataLayer.DataProviders.Tax;
using LSOne.DataLayer.GenericConnector.Enums;
using LSOne.Services.Interfaces;
using LSOne.Utilities.DataTypes;
using LSOne.Utilities.IO;
using LSOne.Utilities.Validation;
using LSOne.ViewCore;
using LSOne.ViewCore.Dialogs;
using LSOne.ViewCore.Enums;
using LSOne.ViewCore.EventArguments;

namespace LSOne.ViewPlugins.ExtendedWarranty.Views
{
	public partial class HelloWorldView : ViewBase
	{

		public HelloWorldView()
		{
			InitializeComponent();

			Attributes = ViewAttributes.Revert |
				ViewAttributes.Save |
				ViewAttributes.Help |
				ViewAttributes.Close |
				ViewAttributes.ContextBar;
		}

		protected override string LogicalContextName
		{
			get
			{
				return Properties.Resources.HelloWorldCmd;
			}
		}

		public override RecordIdentifier ID
		{
			get 
			{ 
				 // If our sheet would be multi-instance sheet then we would return context identifier UUID here,
				 // such as User.GUID that identifies that particular User. For single instance sheets we return 
				// RecordIdentifier.Empty to tell the framework that there can only be one instace of this sheet, which will
				 // make the framework make sure there is only one instance in the viewstack.
				return RecordIdentifier.Empty;
			}
		}

		protected override void LoadData(bool isRevert)
		{
			if (isRevert)
			{
				// Do any possible re-load on rever logic here.
				MessageDialog.Show("We got a Revert request");
			}

			HeaderText = Properties.Resources.Hello;
		}

		protected override bool DataIsModified()
		{
			// Here our sheet is supposed to figure out if something needs to be saved and return
			// true if something needs to be saved, else false.
			return false;
		}

		protected override bool SaveData()
		{
			// Here we would let our sheet save our data.

			// We return true since saving was successful, if we would return false then
			// the viewstack will prevent other sheet from getting shown.
			return true;
		}

		public override void OnDataChanged(DataEntityChangeType changeHint, string objectName, RecordIdentifier changeIdentifier, object param)
		{
			// We use this one if we want to listen to changes in the Viewstack, like was there a user 
			// changed on a user sheet in the viewstack ? And it matters to our sheet ? if so then no
			// probel we catch it here and react if needed

			if (objectName == "User")
			{
				if (changeHint == DataEntityChangeType.Delete)
				{
					// User was deleted and we react on it here if it makes sense
				}
			}

		}

		protected override void OnSetupContextBarHeaders(ContextBarHeaderConstructionArguments arguments)
		{

		}

		protected override void OnSetupContextBarItems(ContextBarItemConstructionArguments arguments)
		{
			if (arguments.CategoryKey == base.GetType().ToString() + ".Related")
			{
				// In most case we would want to check permissions here since it would be likely that the
				// related sheets have different permission needs than the one your on, but its not always
				// the case.
				//if (PluginEntry.Connection.CheckPermission(Permission.SecurityManageUserPermissions))
				//{
				arguments.Add(new ContextBarItem(Properties.Resources.Hello1, new ContextbarClickEventHandler(Hello1_Handler)), 300);
				arguments.Add(new ContextBarItem(Properties.Resources.Hello2, new ContextbarClickEventHandler(Hello2_Handler)), 304);
				//}


			}
		}


		private void Hello1_Handler(object sender, ContextBarClickEventArguments args)
		{
			MessageDialog.Show(Properties.Resources.Clicked + " " + Properties.Resources.Hello1);
		}

		private void Hello2_Handler(object sender, ContextBarClickEventArguments args)
		{
			MessageDialog.Show(Properties.Resources.Clicked + " " + Properties.Resources.Hello2);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            IDataReader dr;

            dr = PluginEntry.DataModel.Connection.ExecuteReader(
                "declare @connectionUser uniqueidentifier set @connectionUser = CAST(CONTEXT_INFO() as uniqueidentifier) select @connectionUser as X");

            if (dr.Read())
            {
                MessageDialog.Show(dr["X"].ToString());
            }

            dr.Close();
        }

        [RecordIdentifierValidation(RecordIdentifier.RecordIdentifierType.Decimal)]
        public RecordIdentifier MyProp { get; set; }

        [StringLength(10)]
        public string Zip  { get; set; }

        private void Test1()
        {
            StatementInfo statement = new StatementInfo();
            DateTime startingTime = DateTime.Now.AddDays(-1);
            DateTime endingTime = DateTime.Now;
            statement.StoreID = "S0001";
            statement.StartingTime = startingTime;
            statement.EndingTime = endingTime;
            statement.PostingDate = Date.Now;

            Providers.StatementInfoData.Save(PluginEntry.DataModel, statement);                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TaxCode code;
            long baseTime;
            long timeA;
            long timeB;

            baseTime = DateTime.UtcNow.Ticks;

            for(int a = 0; a < 100; a++)
            {
                code = Providers.TaxCodeData.Get(PluginEntry.DataModel, "MA-S", CacheType.CacheTypeNone);
            }

            timeA = DateTime.UtcNow.Ticks - baseTime;

            baseTime = DateTime.UtcNow.Ticks;

            for (int a = 0; a < 100; a++)
            {
                code = Providers.TaxCodeData.Get(PluginEntry.DataModel, "MA-S", CacheType.CacheTypeTransactionLifeTime);
            }

            timeB = DateTime.UtcNow.Ticks - baseTime;

            MessageDialog.Show("Without cache: " + timeA.ToString() + "\nWith cache: " + timeB.ToString() + "\nGain: " + ((1.0 - ((timeB * 1.0) / (timeA * 1.0))) * 100).ToString("N2") + " %");

            Test1();
            return;
            //Providers.TransactionData.PerformEOD(PluginEntry.DataModel, "STORE!!!", "TERMINAL!!!", new DateTime(2000,1,1,1,1,1));

            //try
            //{
            //    MyProp = "abc";
            //    MyProp = "1234567890";

            //    Zip = "123";

            //    List<ValidationResult> res = new List<ValidationResult>();
            //    bool valid = Validator.TryValidateObject(this, new ValidationContext(this, null, null), res, true);

            //    if (valid)
            //    {
            //        MessageDialog.Show("Valid");
            //    }
            //    else
            //    {
            //        MessageDialog.Show("Not valid");

            //        foreach (ValidationResult a in res)
            //        {
            //            MessageDialog.Show(a.ErrorMessage);
            //        }
            //    }

                
            //}
            //catch (Exception)
            //{
                
                
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IStoreServerService service;

            service = (IStoreServerService)PluginEntry.DataModel.Service(ServiceType.SiteServiceService);

            service.SetAddress("127.0.0.1", 9101);
            service.Connect(PluginEntry.DataModel);
            service.Disconnect();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Copy 
            string basePartnerPath = "C:\\SCDev\\Source";
            FolderItem SCPluginsPartner = new FolderItem(basePartnerPath + "\\StoreController\\Client\\Plugins");
            FolderItem SCServicesPartner = new FolderItem(basePartnerPath + "\\StoreController\\Services");
            FolderItem SCBusinessObjectsPartner = new FolderItem(basePartnerPath + "\\StoreController\\Client\\BusinessObjects");
            FolderItem SCDataProvidersPartner = new FolderItem(basePartnerPath + "\\StoreController\\Client\\DataProviders");
            FolderItem SCDatabaseUtilPartner = new FolderItem(basePartnerPath + "\\LSPOSDatabaseUtility");
            FolderItem SCStoreServerInterfacePartner = new FolderItem(basePartnerPath + "\\LSPOSNET\\ServiceInterfaces\\StoreServerInterface");

            FolderItem SCPluginsOriginal = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\StoreController\\Client\\Plugins");
            FolderItem SCServicesOriginal = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\StoreController\\Services");
            FolderItem SCBusinessObjectsOriginal = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\StoreController\\Client\\BusinessObjects");
            FolderItem SCDataProvidersOriginal = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\StoreController\\Client\\DataProviders");
            FolderItem SCDatabaseUtilOriginal = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\LSPOSDatabaseUtility");
            FolderItem SCStoreServerInterfaceOriginal = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\LSPOSNET\\ServiceInterfaces\\StoreServerInterface");

            if (!SCPluginsPartner.Exists)
            {
                SCPluginsPartner.CreateAsFolder();
                SCPluginsPartner.Locked = false;
            }
            if (!SCBusinessObjectsPartner.Exists)
            {
                SCBusinessObjectsPartner.CreateAsFolder();
                SCBusinessObjectsPartner.Locked = false;
            }
            if (!SCDataProvidersPartner.Exists)
            {
                SCDataProvidersPartner.CreateAsFolder();
                SCDataProvidersPartner.Locked = false;

            }
            if (!SCServicesPartner.Exists)
            {
                SCServicesPartner.CreateAsFolder();
                SCServicesPartner.Locked = false;

            }
            if (!SCDatabaseUtilPartner.Exists)
            {
                SCDatabaseUtilPartner.CreateAsFolder();
                SCDatabaseUtilPartner.Locked = false;
            }
            if (!SCStoreServerInterfacePartner.Exists)
            {
                SCStoreServerInterfacePartner.CreateAsFolder();
                SCStoreServerInterfacePartner.Locked = false;
            }

            SCPluginsOriginal.Copy(SCPluginsPartner, true, new List<string> { "JobScheduler", "LS Licensing", "User" , "bin" , "obj" });
            SCServicesOriginal.Copy(SCServicesPartner, true, new List<string> { "ExcelImporterService" });
            SCBusinessObjectsOriginal.Copy(SCBusinessObjectsPartner, true, new List<string> { "bin", "obj" });
            SCDataProvidersOriginal.Copy(SCDataProvidersPartner, true, new List<string> { "bin", "obj" });
            SCDatabaseUtilOriginal.Copy(SCDatabaseUtilPartner, true, new List<string> { "bin", "obj" });
            SCStoreServerInterfaceOriginal.Copy(SCStoreServerInterfacePartner, true, new List<string> { "bin", "obj" });

            FolderItem.FolderItemAction removeSourceBindingAction = new FolderItem.FolderItemAction(RemoveSourceBindings);
            FolderItem SCPartnerSourceFolder = new FolderItem(basePartnerPath);

            SCPartnerSourceFolder.OnEach(removeSourceBindingAction);

            watch.Stop();
            MessageDialog.Show(watch.Elapsed.ToString());
        }

        private void RemoveSourceBindings(FolderItem folderItem)
        {
            if (folderItem.FileTypeIs("csproj"))
            {
                string[] sourceControlArray = 
                {   "<SccProjectName>SAK</SccProjectName>"
                    ,"<SccLocalPath>SAK</SccLocalPath>"
                    ,"<SccAuxPath>SAK</SccAuxPath>"
                    ,"<SccProvider>SAK</SccProvider>"
                };

                // Make sure the file is not read only
                folderItem.Locked = false;

                // Read entire file
                var fileContent = File.ReadAllLines(folderItem.AbsolutePath);
                    
                // Remove scc bindings
                fileContent = fileContent.Where(x => !sourceControlArray.Contains(x.Trim())).ToArray();

                // Write the content back to the file
                File.WriteAllLines(folderItem.AbsolutePath, fileContent);
            }
            else if (folderItem.FileTypeIs("vssscc") || folderItem.FileTypeIs("vspscc"))
            {
                folderItem.Locked = false;
                folderItem.Delete();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderItem.FolderItemAction removeSourceBindingAction = new FolderItem.FolderItemAction(RemoveSourceBindings);
            FolderItem.FolderItemAction removeDebugFilesAction = new FolderItem.FolderItemAction(RemoveDebugFiles);
            FolderItem SCPartnerFolder = new FolderItem("C:\\LSPOS\\LSPOSNET DEV\\SCPartnerFolder");

            SCPartnerFolder.OnEach(removeSourceBindingAction);
            SCPartnerFolder.OnEach(removeDebugFilesAction);
        }

        private void RemoveDebugFiles(FolderItem folderItem)
        {
            if (folderItem.Directory && (folderItem.Name == "obj" || folderItem.Name == "bin"))
            {
                folderItem.Delete();
            }
        }

        private void FixPluginReferences(FolderItem folderItem)
        {
            FixReferences(folderItem, 5); // We need to go up 5 levels to reach the closed source dlls from a plugin folder
        }
        
        private void FixReferences(FolderItem folderItem, int hintPathDepth)
        {
            if (folderItem.FileTypeIs("csproj"))
            {
                // Make sure the file is not read only
                folderItem.Locked = false;

                // Read entire file
                var fileContent = File.ReadAllLines(folderItem.AbsolutePath);

                FixReferenceArray(fileContent, hintPathDepth);

                // Write the content back to the file
                File.WriteAllLines(folderItem.AbsolutePath, fileContent);
            }

        }

        // Go through the strings array and check if any of the regex match against any of the strings (using the above linq query). 
        // If a match is found then somehow magically replace the next few lines with the correct new lines, partly supplied by the referenceFixArray
        // It would probably be a good idea to input the number of folders-up we need to go so that this method can be used by f.x. plugins and BO and dataproviders etc.
        private void FixReferenceArray(string[] strings, int hintPathDepth)
        {
            string[,] referenceFixArray = new string[,]
            {
	             {"SharedDialogs", "LSRetail.StoreController.SharedDialogs"}
                ,{"ContextBar", "LSRetail.StoreController.Controls.ContextBar"}
                ,{"OperationPanel", "LSRetail.StoreController.Controls.OperationPanel"}
                ,{"ServiceInterfaces", "LSRetail.ServiceInterfaces"}
                ,{"Shared\\SharedControls\\SharedControls", "LSRetail.SharedControls"}
                ,{"Controls\\SharedControls\\SharedControls", "LSRetail.StoreController.Controls.SharedControls"}
                ,{"SharedCore", "LSRetail.StoreController.SharedCore"}
                ,{"SharedDatabase", "LSRetail.StoreController.SharedDatabase"}
                //,{"Shared\Utilities", "LSRetail.Utilities"}
                ,{"DataControls", "LSRetail.StoreController.Controls.DataControls"}
                ,{"DropDownForm", "LSRetail.StoreController.Controls.DropDownForm"}
                ,{"DevUtilities", "DevUtilities"}
                ,{"Transaction", "Transaction"}
                ,{"LSRetail.ReportDesigner", "LSRetail.ReportDesigner"}
                ,{"LSMenuButtonControl", "LSMenuButtonControl"}
                ,{"DataAccess", "DataAccess"}
                ,{"ItemInterface", "ItemInterface"}
                ,{"ServiceInterfaces", "LSRetail.ServiceInterfaces"}
                ,{"WizardOptionButton", "LSRetail.StoreController.Controls.WizardOptionButton"}
                ,{"ButtonGrid", "ButtonGrid"}
                ,{"CardInterface", "CardInterface"}
                ,{"CCTVInterface", "CCTVInterface"}
                ,{"DialogInterface", "DialogInterface"}
                ,{"EFTInterface", "EFTInterface"}
                ,{"ForecourtInterface", "ForecourtInterface"}
                ,{"POSProcesses", "POSProcesses"}
                ,{"PosSkins", "PosSkins"}
                ,{"SystemFramework", "SystemFramework"}
                ,{"SystemSettings", "SystemSettings"}
                ,{"TillLayoutDesigner", "TillLayoutDesigner"}
                
	        };

            for (int i = 0; i < referenceFixArray.Length/2; i++)
            {
                string regExPattern = "<ProjectReference.*" + referenceFixArray[i, 0] + ".csproj";
                int startingNumber = (from s in strings
                                      where Regex.Matches(s, regExPattern).Count > 0
                                      select Array.IndexOf(strings, s)).FirstOrDefault();

                if (startingNumber > 0)
                {
                    string hintPathDepthString = String.Concat(Enumerable.Repeat("..\\", hintPathDepth));

                    strings[startingNumber] = "<Reference Include=\"" + referenceFixArray[i, 1] + "\">";
                    strings[startingNumber + 1] = "<HintPath>" + hintPathDepthString + referenceFixArray[i, 1] + ".dll</HintPath>";
                    strings[startingNumber + 2] = "</Reference>";

                    if (strings[startingNumber + 3].Trim().StartsWith("</ProjectReference>"))
                    {
                        strings[startingNumber + 3] = "";
                    }
                    else
                    {
                        MessageDialog.Show("This point should never be reached. There must be a project reference that I did not anticipate");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderItem folderItem = new FolderItem("C:\\SCDev\\Source\\StoreController\\Client\\Plugins\\CentralSuspensions\\CentralSuspensions.csproj");
            
            // Make sure the file is not read only
            folderItem.Locked = false;

            // Read entire file
            var fileContent = File.ReadAllLines(folderItem.AbsolutePath);

            FixReferenceArray(fileContent, 5);

            // Write the content back to the file
            File.WriteAllLines(folderItem.AbsolutePath, fileContent);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
            string regexString = "<ProjectReference Include=\"..\\..\\..\\Shared\\SharedControls\\SharedControls.csproj\">";
            if (Regex.Matches(regexString, "<ProjectReference.*Shared\\SharedControls\\SharedControls.csproj").Count > 0)
            {
                MessageDialog.Show("bla");
            }
            if (Regex.Matches(regexString, "<ProjectReference.*SharedControls\\SharedControls.csproj").Count > 0)
            {
                MessageDialog.Show("bla");
            }
            if (Regex.Matches(regexString, "<ProjectReference.*\\SharedControls.csproj").Count > 0)
            {
                MessageDialog.Show("bla");
            }
            if (Regex.Matches(regexString, "<ProjectReference.*SharedControls.csproj").Count > 0)
            {
                MessageDialog.Show("bla1");
            }
            */
            /*
            string regexString2 = "\\Shared\\SharedControls";
            if (Regex.Matches(regexString2, "\\Shared\\SharedControls").Count > 0)
            {
                MessageDialog.Show("bla");
            }
             * */
            /*
            string regexString3 = "\\A\\B";
            if (Regex.Matches(regexString3, "\\A\\B").Count > 0)
            {
                MessageDialog.Show("bla");
            }
            */
            /*
            string regexString4 = "\\Shared\\Sh";
            if (Regex.Matches(regexString4, "\\Shared\\Sh").Count > 0)
            {
                MessageDialog.Show("bla");
            }
             */
            string regexString = "\\A";
            if (Regex.Matches(regexString, "\\A").Count > 0)
            {
                MessageDialog.Show("bla");
            }
            string regexString3 = "\\AA";
            if (Regex.Matches(regexString3, "\\AA").Count > 0)
            {
                MessageDialog.Show("bla");
            }

            
        }

        private void btnCallEveryDataMethod_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Providers.PromotionOfferLineData.Get(PluginEntry.DataModel, "S0001-P000001", 0);
            //Providers.PromotionOfferLineData.GetLines(PluginEntry.DataModel, "S0001-P000001", PromotionOfferLineSorting.DiscountPercentage, false);
            //Providers.PromotionOfferLineData.GetValidAndEnabledPromotionsForItem(PluginEntry.DataModel, "00000068", RecordIdentifier.Empty, RecordIdentifier.Empty, RecordIdentifier.Empty);
            //Providers.PromotionOfferLineData.GetValidAndEnabledPromotionsForItem(PluginEntry.DataModel, "00000068", RecordIdentifier.Empty, "S0001", "S0001-00000001");
        }
	}
}
