   M S B A M L   `   `   `  ����A  =AppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AppWPF.ViewAppWPF.View  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	        AppWPF.View.DepartmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AppWPF.View     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  DepartmentView��5	   	   $	��400��6    $	��600��6-   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $
��Name��6   $��0��6   $��0��6,   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly 6/   �� *IsReadOnlyName+��6U   �� *Name+6m   �� 5   
   $��Budget��6   $��1��6!   $��0��6.   �� 5   
   $��1��6   $��1��6    6/   �� *IsReadOnlyBudget+��6W   �� *Budget+6q   �� 5   
   $��Admin��6   $��2��6    $��0��6-   �� 5   
   $��2��6   $��1��6    6/   �� *IsReadOnlyAdmin+��6V   �� *Admin+6o   &   System.Windows.Controls.DataGrid  5   
   $��3��6   $��2��6       AutoGenerateColumns .    AzureDataGrid#��[  5       .@�5!      0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6!   �� *Name+6N   5#      �� 5$   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5%      �� $	��Add��69   $	��Add��6e   {�6   �� *IsEnabledAdd+��6G   �� *	Instancia+6~   �� 5&      $��Delete��6<   $��Delete��6k   {�6   �� *IsEnabledDelete+��6M   �� *	Instancia+6�   �� 5'      $��Update��6;   $��Update��6j   {�6   �� *IsEnableUpdate+��6L   �� *	Instancia+6�   �� 5(      $
��Save��69   $
��Save��6f   {�6   �� *IsEnableSave+��6H   �� *	Instancia+6�   �� 5)      $��Cancel��6;   $��Cancel��6j   {�6   �� *IsEnableCancel+��6L   �� *	Instancia+6�   5*      5,      5-      