   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.FrmProdaja   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni prodaju��5   	   $	��250��6&   $	��320��63   ���#c6e7c9.��5
      � .+�5   
   �� $��Artikal:��6   $
��Left=�6#   $��	30,20,0,0q�6>   $	��Top=�6Q   �� 5   
   $��	ReceptID:��6   $
��Left=�6$   $��	30,50,0,0q�6?   $	��Top=�6R   �� 5   
   $��
Zaposleni:��6   $
��Left=�6%   $��	30,80,0,0q�6@   $	��Top=�6S   �� 5   
   $��Datum:��6   $
��Left=�6!   $��
30,110,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ cbArtikalID��5      $
��Left=�6(   $��
135,20,0,0q�6C   $	��Top=�6W   $	��120��6o    J� RenderTransformOrigin$ 0.507,-2.246&�6{    �� DisplayMemberPath$ Artikal��6�    �� SelectedValuePath$ 	ArtikalID��6�   �� 5   
   -   5        $ 
cbReceptID��5      $
��Left=�6'   $��
135,50,0,0q�6B   $	��Top=�6V   $	��120��6n   $ 0.507,-2.246&�6z   $ ReceptID��6�   $ ReceptID��6�   �� 5   
   -   5        $ cbZaposleniID��5      $
��Left=�6*   $��
135,80,0,0q�6E   $	��Top=�6Y   $	��120��6q   $ 0.507,-2.246&�6}   $ 	Zaposleni��6�   $ ZaposleniID��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumProdaje��5      $
��Left=�6+   $��135,110,0,0q�6F   $	��Top=�6[   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $��Right=�67   $��
0,0,100,10q�6S   $��Bottom=�6g   $��75��6�      Stil#��[  6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $��Right=�65   $��	0,0,10,10q�6Q   $��Bottom=�6d   $��75��6   #��[  6�   5      5      