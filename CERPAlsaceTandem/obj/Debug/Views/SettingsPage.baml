   M S B A M L   `   `   `  ����K  GCERPAlsaceTandem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CERPAlsaceTandem.ViewsCERPAlsaceTandem.Views  5      M+clr-namespace:CERPAlsaceTandem.UserControlsCERPAlsaceTandem.UserControls  5      )    #CERPAlsaceTandem.Views.SettingsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CERPAlsaceTandem.Views     5      DuserControls+clr-namespace:CERPAlsaceTandem.UserControls     5        N� Title$  SettingsPage��5
      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� $��Center=�6   	Theme :68   �� 5   
   $��5q�6   $��1��6   $��0��6.   ��6;   �� *Themes+ �� SelectedItem 6Z   �� *SelectedTheme+ �� Mode$ TwoWay=�6�   �� 5   
   $��0��6   $��Center=�6$   $��1��6?   Couleur principal :6a   �� 5   
   $��5q�6   $��1��6   $��1��6.   ��6;   �� *ThemeAccents+ 6`   �� *SelectedAccent+$ TwoWay=�6�   �� 5   
   $��0��6   $��Center=�6$   $��2��6?   Dossier Principal :6a   0   *CERPAlsaceTandem.UserControls.FolderPicker  5   
   $��5q�6$   $��1��6/   $��2��6?      Folder 6L   �� *Path+$ TwoWay=�6s   �� 5!   
   $��Valider��6   $��5q�6#   $��3��6.   $��0��6;   $��2��6K   $��Right=�6_   ��6{   �� *GoBackCommand+6�   5"      5#      