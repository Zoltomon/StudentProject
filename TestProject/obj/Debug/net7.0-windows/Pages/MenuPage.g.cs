﻿#pragma checksum "..\..\..\..\Pages\MenuPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F26414E7CD163874DA20E8AD41A3C07185F28D25"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TestProject.Pages;


namespace TestProject.Pages {
    
    
    /// <summary>
    /// MenuPage
    /// </summary>
    public partial class MenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStudent;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnTeacher;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLessons;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGradeStudent;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGroup;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Pages\MenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestProject;component/pages/menupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\MenuPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnStudent = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Pages\MenuPage.xaml"
            this.BtnStudent.Click += new System.Windows.RoutedEventHandler(this.BtnStudent_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnTeacher = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Pages\MenuPage.xaml"
            this.BtnTeacher.Click += new System.Windows.RoutedEventHandler(this.BtnTeacher_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnLessons = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Pages\MenuPage.xaml"
            this.BtnLessons.Click += new System.Windows.RoutedEventHandler(this.BtnLessons_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnGradeStudent = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Pages\MenuPage.xaml"
            this.BtnGradeStudent.Click += new System.Windows.RoutedEventHandler(this.BtnGradeStudent_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnGroup = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Pages\MenuPage.xaml"
            this.BtnGroup.Click += new System.Windows.RoutedEventHandler(this.BtnGroup_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnExit = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\Pages\MenuPage.xaml"
            this.BtnExit.Click += new System.Windows.RoutedEventHandler(this.BtnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

