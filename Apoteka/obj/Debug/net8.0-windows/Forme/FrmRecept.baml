   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.FrmRecept   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni recept��5   	   $	��200��6%   $	��350��62   ���#c6e7c9.��5
      � .+�5   
   �� $��Datum izdavanja:��6   $
��Left=�6+   $��	30,20,0,0q�6F   $	��Top=�6Y   �� 5   
   $��	Pacijent:��6   $
��Left=�6$   $��	30,50,0,0q�6?   $	��Top=�6R   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumIzdavanjaRecepta��5      $
��Left=�64   $��
180,20,0,0q�6O   $	��Top=�6c   �� 5   
   -   5         ��Name$ 	cbKupacID��5      $
��Left=�6&   $��
180,50,0,0q�6A   $	��Top=�6U   $	��120��6m    J� RenderTransformOrigin$ 0.507,-2.246&�6y    �� DisplayMemberPath$ Pacijent��6�    �� SelectedValuePath$ KupacID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $��Right=�67   $��
0,0,100,10q�6S   $��Bottom=�6g   $��75��6�      Stil#��[  6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $��Right=�65   $��	0,0,10,10q�6Q   $��Bottom=�6d   $��75��6   #��[  6�   5      5      