   M S B A M L   `   `   `  ����H  DObsługa Taxi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Obsługa_Taxi.HelpersObsługa_Taxi.Helpers  5      9!clr-namespace:Obsługa_Taxi.ViewsObsługa_Taxi.Views  5      -clr-namespace:Obsługa_TaxiObsługa_Taxi  5      "    Obsługa_Taxi.Views.TaxiView   5      /helpers#clr-namespace:Obsługa_Taxi.Helpers  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Obsługa_Taxi.Views     5      5Obsługa_Taxiclr-namespace:Obsługa_Taxi     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5
        N� Title$  TaxiView��5       � DataContext 5      �� 5   
    �� Path$ TaxiView�6      Locator �� Source# [  6"   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6%   �� *LoadedCommand+ �� Mode$ OneWay=�5      .��5      � $��80,135,80,10q�6   	 � RowDefinitions	 5   
   �� 5      $��50 �6   �� 5      $	��64* �6   �� 5      $��64 �6   .+�5   
   �� $��18(�6   $��0��6   $��Center=�6+   $	��Top=�6H   $��34��6`   $��44��6l   .��5      �� �� 6   .�6   �� $
�Taxi��6#   62   69   5      �� 5   
   $��0��6   $��Center=�6   $��Bottom=�6:   $	��134��6U   .��5       �� �� 6   .�6   �� $�Wybierz taksówkarza:��6#   6B   6I   5!      �� 5"   
   -   5        
 ��Name$
 ListBox��5"      $��1��6#   $��10,10,10,10q�60   ��6E   �� *Taxis+ �� SelectedItem 6c   �� *
taksowkarz+��5#      �� 5$      .R�5%      �  � ColumnDefinitions 5&      �� 5'      $��* �6/   .+�5)      �� $��1��6%   $��5q�65   .+�5*      ��  �� Orientation$ 
Horizontal=�6)   $
��Bold"�6B   .+�5+   "   �� ��6,   �� *Imie+�� 5,   "    �� Padding$ 3,0,0,0q�6F   ��6,   �� *
Nazwisko+6F   5-      �� 5.      ��6(   �� *TaxiID+�� 5/      ��6(   �� *AktualnyAdres+50      51      52      54      �� 55   
   -   5         ��Name$ Zamow��55      $��2��6    $
��Left=�6-   $	��Top=�6H   $	��253��6`   $��57��6l   
��� � �$��20(�6�   $��25,0,0,0q�6�   .��56      �� �� 6   .�6   �� $�Zamów��6#   63   6:   57      �� 58   
   -   5        $ Wstecz��58      $��2��6!   $��Right=�6.   $	��Top=�6J   $	��253��6b   $��57��6n   
���  ��$��20(�6�   $��0,0,25,0q�6�   ��6�   �� *GoBackCommand+.��59      �� �� 6   .�6   �� $�Wstecz��6#   64   6;   5:      5;      5<      