   M S B A M L   `   `   `  ����H  DGeliGider_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GeliGider_WPFGeliGider_WPF  5   	       GeliGider_WPF.GelirEkle   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GeliGider_WPF     5   	   -   5          � Title$  
Gelir Ekle��5   	   $	��419��6   $	��467��6)    � 
ResizeMode$ NoResize=�65   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 1Q�6)   � 5      $ 	#FF99B8EE��6   5      .��5      �  � RowDefinitions 5   
   �� 5      ��5   
   �� 5      $ 0.5,1&�6"   $ 0.5,0&�63   .��5      � $ 	#FF1B263A��6   $ 1Q�61   � 5      $ 	#FF99B8EE��6   5      .+�5   
   �� -   5         ��Name$ label��5      $��Tarih :��6   $
��Left=�61   $��	36,69,0,0q�6L   $	��Top=�6_   $
��Bold"�6w   $��Italic$�6�   $��56��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtTarih��5      $
��Left=�6&   $��
111,69,0,0q�6A   $	��Top=�6U   $	��137��6m   �� 5   
   -   5        $ label1��5      $��Miktar :��6    $
��Left=�63   $��
38,124,0,0q�6N   $	��Top=�6b   $
��Bold"�6z   $��Italic$�6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       
 �� Angle$
 0.661Q�6&   T� 5!      5"      5$      �� 5%   
   -   5         ��Name$ 
txb_Miktar��5%      $
��Left=�6&   $��23��6A   $��111,120,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��160��6�   �� 5&   
   -   5        $ label3��5&      $��
Kategori :��6    $
��Left=�65   $��
36,173,0,0q�6P   $	��Top=�6d   $
��Bold"�6|   $��Italic$�6�   �� 5'   
   -   5         ��Name$ cmb_Kategori��5'      $
��Left=�6)   $��111,173,0,0q�6D   $	��Top=�6Y   $	��160��6q   6}   �� 5(   
   -   5        $ label4��5(      $��Açıklama :��6    $
��Left=�65   $��
36,226,0,0q�6P   $	��Top=�6d   $
��Bold"�6|   $��Italic$�6�   �� 5)   
   -	   5         ��Name$ button��5)      $
��EKLE��6!   $
��Left=�60   $��157,328,0,0q�6K   $	��Top=�6`   $��91��6x   $
��Bold"�6�   $��Italic$�6�   6�   �� 5*   
   -
   5         ��Name$ image��5*      $
��Left=�6   $��92��6:   $��309,173,0,0q�6F   $	��Top=�6[   $��88��6s   $��gelirEkle.png��6~   �� 5+   
   -   5        $ 
image_Copy��5+      $
��Left=�6$   $��58��6?   $��356,110,0,0q�6K   $	��Top=�6`   $��69��6x   $��gelirEkle.png��6�   �� 5,   
   -   5        $ image_Copy1��5,      $
��Left=�6%   $��35��6@   $��
396,60,0,0q�6L   $	��Top=�6`   $��53��6x   $��gelirEkle.png��6�   �� 5-   
   -   5        $ txbAciklama��5-      $
��Left=�6'   $��66��6B   $��111,230,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��160��6�   5/      50      