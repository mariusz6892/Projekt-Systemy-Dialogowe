   M S B A M L   `   `   `  ���� H  DObsługa Taxi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Obsługa_Taxi.ViewsObsługa_Taxi.Views  #    Obsługa_Taxi.Views.LoginView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:Obsługa_Taxi.Views       N� Title$  	LoginView�� � DataContext �� *	LoginView+   Locator �� Source# [  .��� .+��� -    ��Name$ LogIn��$
��Left=�$��
50,287,0,0q�$	��Top=�$	��253��$��57��
��� � �$��20(�.���� �� .��� $�	Logowanie���� -   $ Register��$��Right=�$��
0,287,50,0q�$	��Top=�$	��253��$��57��
���  ��$��20(�.���� �� .��� $�Rejestracja��� -    �Name$ 
PopupLogin�� � AllowsTransparency . $��Center=�$��Center=�$��Slide=�$��Center=�$	��300��$	��120��.���  � RowDefinitions �� �� �� �� .+��� $��18(�$��0��$��0,0,0,10q�$��2��.���� �� .��� $�	Logowanie���� $��1��.���� �� .��� $�Podaj numer telefonu:���� -   $ LogowaniePopup��$��3��$
��Left=�$	��100��$��20��
��� � �{�.  $��10,5,0,5q����� *AdresCommand+.���� �� .��� $�	Logowanie���� -    ��Name$ NumberTextBox��$��30��$��2�� �� 	MaxLength$ 9������ *
nrtelefonu+	 �� Mode$	 OneWayToSource=��� -   $ ZamknijPopup��$��3��$��Right=�$	��100��$��20��
���  ��.���� �� .��� $�Zamknij��� -   $ PopupRegister�� . $��Center=�$��Center=�$��Slide=�$��Center=�$	��300��$	��120��.���  �� �� �� �� .+��� $��18(�$��0��$��0,0,0,10q�$��2��.���� �� .��� $�Rejestracja���� $��1��.���� �� .��� $�Podaj numer telefonu:���� -   $ RegisterPopup��$��3��$
��Left=�$	��100��$��20��
��� � �{�.  ���� *RegisterCommand+.���� �� .��� $�Rejestracja���� -	   $ NumberTextBoxReg��$��30��$��2��$ 9������ *
nrtelefonu+$	 OneWayToSource=��� -
   $ ZamknijPopupReg��$��3��$��Right=�$	��100��$��20��
���  ��.���� �� .��� $�Zamknij��