   M S B A M L   `   `   `  ����K  GCERPAlsaceTandem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CERPAlsaceTandem.UserControlsCERPAlsaceTandem.UserControls  5      0    *CERPAlsaceTandem.UserControls.PassengerBox   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:CERPAlsaceTandem.UserControls     5      .��5	      �� $��2��6      AccentColorBrush#��[  6   $��15q�6J   ._�5
   
   � $��20q�6     � ColumnDefinitions  5      �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   �� 5      $
��Auto �6    60   .+�5      �� $��	10,0,15,0q�6   $
��Bold"�6+   $��0��6=   $��0��6M   Nom du passager :6m   �� 5      $��	10,0,15,0q�6   $
��Bold"�6+   $��0��6=   $��1��6M   Type de tandem :6l   �� 5      $��	10,0,15,0q�6   $
��Bold"�6+   $��0��6=   $��2��6M   Date :6b   �� 5      $��	10,0,15,0q�6   $
��Bold"�6+   $��0��6=   $��3��6M   Préstation :6h   �� 5      $��1��6   $��0��6(   $��15(�65   ��6C   �� *
FullName+6_   �� 5      $��1��6   $��1��6(   ��65   �� *IsCEP+  BoolToTandemTypeConverter �� 	Converter# [ 6�   �� 5      $��1��6   $��2��6(   ��65   �� *Date+ �� StringFormat$ D��6]   �� 5       $��1��6   $��3��6(   ��65   �� *
TandemType+  TandemTypeToStringConverter# [ 6�   � 5"      -   5        $��2��5"      $��0��6#   $��3��60   y�6g   �� *PhotoFolderExist+  BoolToVisitibilityConverter# [ .+�5#      �� $��10q�6   $	��100��6$   $	��100��61   $��/Images/folderPhoto.png��6=   6`   � 5$      $
��Left=�6   $��Bottom=�62   $��15q�6M   .+�5%      A� $��30��6   $��30��6*   
���   �6D   �� 5&      
�������$��Center=�63   $��Center=�6P   ��6k   �� *
PhotoCount+6�   5'      5(      � 5*      $��3��6   $��0��6#   $��3��60   y�6A   �� *VideoFolderExist+# [ .+�5+      �� $��10q�6   $	��100��6$   $	��100��61   $��/Images/folderVideo.png��6=   6`   � 5,      $
��Left=�6   $��Bottom=�62   $��15q�6M   .+�5-      A� $��30��6   $��30��6*   
���   �6D   �� 5.      
�������$��Center=�63   $��Center=�6P   ��6k   �� *
VideoCount+6�   5/      50      �� 52      $��3��6   $��2��6"   $��2��62   $%��Sélectionner un autre passager��6x   ��6F   �� *GoToPassengerSelectionCommand+6�   54      55      56      