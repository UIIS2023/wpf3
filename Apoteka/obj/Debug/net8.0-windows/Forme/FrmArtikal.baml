   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.FrmArtikal   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni artikal��5   	   $	��300��6&   $	��320��63   ���#c6e7c9.��5      � .+�5   
   �� $��Naziv:��6   $
��Left=�6!   $��	30,20,0,0q�6<   $	��Top=�6O   �� 5   
   $��Oblik:��6   $
��Left=�6!   $��	30,50,0,0q�6<   $	��Top=�6O   �� 5   
   $��Proizvodjač:��6   $
��Left=�6'   $��	30,80,0,0q�6B   $	��Top=�6U   �� 5   
   $��Dobavljač:��6   $
��Left=�6%   $��
30,110,0,0q�6@   $	��Top=�6T   �� 5   
   $��
Na stanju:��6   $
��Left=�6%   $��
30,140,0,0q�6@   $	��Top=�6T   �� 5   
   $��Cena:��6   $
��Left=�6    $��
30,170,0,0q�6;   $	��Top=�6O   �� 5   
   $
��PDV:��6   $
��Left=�6   $��
30,200,0,0q�6:   $	��Top=�6N   �� 5   
   -   5         ��Name$ txtNazivArtikla��5      $
��Left=�6+   $��23��6F   $��
135,20,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ cbTipArtikla��5      $
��Left=�6)   $��
135,50,0,0q�6D   $	��Top=�6X   $	��120��6p    J� RenderTransformOrigin$ 0.507,-2.246&�6|    �� DisplayMemberPath$ Oblik��6�    �� SelectedValuePath$ TipArtiklaID��6�   �� 5   
   -   5        $ cbProizvodjac��5      $
��Left=�6*   $��
135,80,0,0q�6E   $	��Top=�6Y   $	��120��6q   $ 0.507,-2.246&�6}   $ NazivProizvodjača��6�   $ ProizvodjačID��6�   �� 5   
   -   5        $ cbDobavljac��5      $
��Left=�6(   $��135,110,0,0q�6C   $	��Top=�6X   $	��120��6p   $ 0.507,-2.246&�6|   $ NazivDobavljača��6�   $ DobavljačID��6�   �� 5   
   -   5        $ 	txtStanje��5      $
��Left=�6%   $��23��6@   $��135,140,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -   5        $ txtCena��5      $
��Left=�6#   $��23��6>   $��135,170,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ txtPDV��5      $
��Left=�6"   $��23��6=   $��135,200,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $��Right=�67   $��
0,0,100,10q�6S   $��Bottom=�6g   $��75��6�      Stil#��[  6�   �� 5   
   -	   5        $ 	btnOtkazi��5      $��Otkaži��6$   $��Right=�65   $��	0,0,10,10q�6Q   $��Bottom=�6d   $��75��6   #��[  6�   5      5       