﻿#pragma checksum "..\..\..\..\Pages\TeacherPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4894A8B5D7015DB9B2A61CEE23B5794DCD0A6961"
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
    /// TeacherPage
    /// </summary>
    public partial class TeacherPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPostTeacher;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRefresh;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridTeacher;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbBrindStudent;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBrindTeacherCSV;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBrindTeacherXLS;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxbSearch;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Pages\TeacherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNameFilter;
        
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
            System.Uri resourceLocater = new System.Uri("/TestProject;component/pages/teacherpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\TeacherPage.xaml"
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
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Pages\TeacherPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnPostTeacher = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\TeacherPage.xaml"
            this.BtnPostTeacher.Click += new System.Windows.RoutedEventHandler(this.BtnPostTeacher_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Pages\TeacherPage.xaml"
            this.BtnRefresh.Click += new System.Windows.RoutedEventHandler(this.BtnRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataGridTeacher = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.CmbBrindStudent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.BtnBrindTeacherCSV = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\Pages\TeacherPage.xaml"
            this.BtnBrindTeacherCSV.Click += new System.Windows.RoutedEventHandler(this.BtnBrindTeacherCSV_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnBrindTeacherXLS = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Pages\TeacherPage.xaml"
            this.BtnBrindTeacherXLS.Click += new System.Windows.RoutedEventHandler(this.BtnBrindTeacherXLS_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TxbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 87 "..\..\..\..\Pages\TeacherPage.xaml"
            this.TxbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnNameFilter = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 56 "..\..\..\..\Pages\TeacherPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

