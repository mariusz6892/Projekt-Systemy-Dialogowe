   M S B A M L   `   `   `  ����H  DObsługa Taxi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Obsługa_Taxi.HelpersObsługa_Taxi.Helpers  5      9!clr-namespace:Obsługa_Taxi.ViewsObsługa_Taxi.Views  5      *    $Obsługa_Taxi.Views.PodsumowanieView   5      /helpers#clr-namespace:Obsługa_Taxi.Helpers  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Obsługa_Taxi.Views     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5	        N� Title$  PodsumowanieView��5       � DataContext 5      �� 5   
    �� Path$ PodsumowanieView�6      Locator �� Source# [  6*   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6%   �� *LoadedCommand+ �� Mode$ OneWay=�5      .��5      � $��	0,170,0,0q�6   	 � ColumnDefinitions	 5   
   �� 5      $��* �6   .+�5   
   �� $��1��6   $��5q�6%   $
��Bold"�60   .+�5      �� 
 �� Orientation$
 
Horizontal=�6   $
��Bold"�62   .+�5      �� $��Wybrałeś taksówkarza: ��6   �� 5      ��6   �� *
imietaxi+�� 5       �� Padding$ 3,0,0,0q�6:   ��6   �� *nazwiskotaxi+6:   5      �� 5      $��Wybrany adres:��6   �� 5       ��6   �� *	adresdo+�� 5!      $��Twój numer telefonu:��6   �� 5"      ��6   �� *
nrtelefonu+5#      �� 5$   
   -   5         ��Name$ Zamow��5$      $
��Left=�6    $��Bottom=�6;   $	��253��6V   $��57��6b   
��� � �$��20(�6�   $��	35,0,0,37q�6�   ��6�   �� *ConfirmCommand+.��5%      �� �� 6   .�6   �� $�
Potwierdź��6#   67   6>   5&      �� 5'   
   -   5        $ Wstecz��5'      $��Right=�6!   $��Bottom=�6=   $	��253��6X   $��57��6d   
���  ��$��20(�6�   $��	0,0,35,37q�6�   ��6�   �� *ResignCommand+.��5(      �� �� 6   .�6   �� $�	Zrezygnuj��6#   67   6>   5)      5*      5+      