﻿#pragma checksum "E:\StarFianance\Tafe21S2NSJ\StarFinanceMaster\InstaRichie\Views\PersonalInfoPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "549D97789E85A935EF2D7CA12C5C26B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StartFinance.Views
{
    partial class PersonalInfoPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class PersonalInfoPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPersonalInfoPage_Bindings
        {
            private global::StartFinance.Views.PersonalInfoPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.AppBarButton obj22;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj23;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj24;

            // Fields for each event bindings event handler.
            private global::Windows.UI.Xaml.RoutedEventHandler obj22Click;
            private global::Windows.UI.Xaml.RoutedEventHandler obj23Click;
            private global::Windows.UI.Xaml.RoutedEventHandler obj24Click;

            // Static fields for each binding's enabled/disabled state

            public PersonalInfoPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 72 && columnNumber == 31)
                {
                    this.obj22.Click -= obj22Click;
                }
                else if (lineNumber == 73 && columnNumber == 31)
                {
                    this.obj23.Click -= obj23Click;
                }
                else if (lineNumber == 74 && columnNumber == 31)
                {
                    this.obj24.Click -= obj24Click;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 22: // Views\PersonalInfoPage.xaml line 72
                        this.obj22 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        this.obj22Click = (global::System.Object p0, global::Windows.UI.Xaml.RoutedEventArgs p1) =>
                        {
                            this.dataRoot.ViewModel.GotoSettings();
                        };
                        ((global::Windows.UI.Xaml.Controls.AppBarButton)target).Click += obj22Click;
                        break;
                    case 23: // Views\PersonalInfoPage.xaml line 73
                        this.obj23 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        this.obj23Click = (global::System.Object p0, global::Windows.UI.Xaml.RoutedEventArgs p1) =>
                        {
                            this.dataRoot.ViewModel.GotoPrivacy();
                        };
                        ((global::Windows.UI.Xaml.Controls.AppBarButton)target).Click += obj23Click;
                        break;
                    case 24: // Views\PersonalInfoPage.xaml line 74
                        this.obj24 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        this.obj24Click = (global::System.Object p0, global::Windows.UI.Xaml.RoutedEventArgs p1) =>
                        {
                            this.dataRoot.ViewModel.GotoAbout();
                        };
                        ((global::Windows.UI.Xaml.Controls.AppBarButton)target).Click += obj24Click;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IPersonalInfoPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::StartFinance.Views.PersonalInfoPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::StartFinance.Views.PersonalInfoPage obj, int phase)
            {
                if (obj != null)
                {
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\PersonalInfoPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // Views\PersonalInfoPage.xaml line 16
                {
                    this.ViewModel = (global::StartFinance.ViewModels.MainPageViewModel)(target);
                }
                break;
            case 4: // Views\PersonalInfoPage.xaml line 35
                {
                    this.AdaptiveVisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 5: // Views\PersonalInfoPage.xaml line 36
                {
                    this.VisualStateNarrow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 6: // Views\PersonalInfoPage.xaml line 45
                {
                    this.VisualStateNormal = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 7: // Views\PersonalInfoPage.xaml line 54
                {
                    this.VisualStateWide = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 8: // Views\PersonalInfoPage.xaml line 66
                {
                    this.pageHeader = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 9: // Views\PersonalInfoPage.xaml line 79
                {
                    this.pageFooter = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 10: // Views\PersonalInfoPage.xaml line 87
                {
                    this.InternFooter = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 11: // Views\PersonalInfoPage.xaml line 97
                {
                    this.pagecontent = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                    ((global::Windows.UI.Xaml.Controls.Pivot)this.pagecontent).SelectionChanged += this.Pivot_SelectionChanged;
                }
                break;
            case 12: // Views\PersonalInfoPage.xaml line 105
                {
                    this.PageStart = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 13: // Views\PersonalInfoPage.xaml line 108
                {
                    this.UserIdTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // Views\PersonalInfoPage.xaml line 109
                {
                    this.SearchByIdBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SearchByIdBtn).Click += this.SearchByIdBtn_Click;
                }
                break;
            case 15: // Views\PersonalInfoPage.xaml line 110
                {
                    this.FullNameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // Views\PersonalInfoPage.xaml line 111
                {
                    this.EmailTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // Views\PersonalInfoPage.xaml line 112
                {
                    this.ContactTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 18: // Views\PersonalInfoPage.xaml line 113
                {
                    this.AddBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddBtn).Click += this.AddBtn_Click;
                }
                break;
            case 19: // Views\PersonalInfoPage.xaml line 114
                {
                    this.EditBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.EditBtn).Click += this.EditBtn_Click;
                }
                break;
            case 20: // Views\PersonalInfoPage.xaml line 115
                {
                    this.DeleteBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.DeleteBtn).Click += this.DeleteBtn_Click;
                }
                break;
            case 21: // Views\PersonalInfoPage.xaml line 117
                {
                    this.PersonalInfoList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\PersonalInfoPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    PersonalInfoPage_obj1_Bindings bindings = new PersonalInfoPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

