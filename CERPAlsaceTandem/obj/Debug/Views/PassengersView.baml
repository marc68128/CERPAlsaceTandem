   M S B A M L   `   `   `  ����K  GCERPAlsaceTandem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CERPAlsaceTandem.ViewsCERPAlsaceTandem.Views  5      +    %CERPAlsaceTandem.Views.PassengersView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CERPAlsaceTandem.Views     5        N� Title$  PassengerView��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��3* �6   6*   .+�5   
   �� $��/Images/CERPA.png��6   $��Center=�6+   6J   � 5   
   $��1��6   $��20,20,20,10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   .+�5      �� $��20(�6   $*��$Veuillez sélectionner un passager :��6&   6S   �� 5      $
��10,0q�6   $��2��6'    �� Orientation$ 
Horizontal=�67   .+�5      ��  d� 	IsChecked 6   �� *	ShowPhoto+ �� Mode$ TwoWay=�6J   �� 5      $��Center=�6   $��photo��67   6F   5       �� 5!      $
��10,0q�6   $��3��6'   $ 
Horizontal=�67   .+�5"      ��  6   �� *	ShowVideo+$ TwoWay=�6J   �� 5#      $��Center=�6   $��video��67   6F   5$      �� 5%      $��4��6d   ��6   �� *
SearchTerm+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6v   5'      �� 5(   
   $
��20,0q�6   $��2��6#   $��Stretch=�60   $��2��6N      AccentColorBrush4#��[  6Y   6�   �� 5)   
   $��3��6   .��5*      �� $��20q�6   ��6"   �� *
Passengers+ �� SelectedItem 6E   �� *SelectedPassenger+$ TwoWay=���5+      �� 5,      .R�5-      � $��10q�6    5.      �� 5/   "   $��* �63   6?   �� 50   "   $
��Auto �63   6B    52      �� 53   "   $
��Auto �60   6@   �� 54   "   $
��Auto �60   6@   .+�56      �� $��15(�6(   ��66   �� *
FullName+6R   �� 57      $��0��6(   $��1��68   ��6E   �� *IsCEP+  BoolToTandemTypeConverter �� 	Converter# [ 6�   �� 58      	 �� TextAlignment$	 Right=�6(   $��Right=�6>   $��1��6Z   $��0��6j   ��6w   �� *Date+
 �� StringFormat$
 d��6�   �� 59      $	 Right=�6(   $��Right=�6>   $��1��6Z   $��1��6j   ��6w   �� *
TandemType+  TandemTypeToStringConverter# [ 6�   5:      5;      5=      5>      5?      5@      