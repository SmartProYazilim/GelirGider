   M S B A M L   `   `   `  ����H  DGeliGider_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GeliGider_WPFGeliGider_WPF  5   	   "    GeliGider_WPF.SifremiUnuttum   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GeliGider_WPF     5   	   -   5          � Title$  Şifremi Unuttum��5   	   $��268.481��6!   $��518.722��62    � 
ResizeMode$ NoResize=�6B   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $
��512* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF1B263A��6    � Offset$ 1Q�61   � 5      $ 	#FF99B8EE��6   5      .+�5   
   �� -   5         ��Name$ lblEmail��5      $��E-mail :��6"   $
��Left=�65   $��30��6P   $��	49,54,0,0q�6\   $	��Top=�6o   $��77��6�   $
��Bold"�6�   $��Italic$�6�   $��1��6�   �� 5   
   -   5         ��Name$ txbEmail��5      $
��Left=�6$   $��25��6?   $��
174,54,0,0q�6K   	 �� TextWrapping$
	 Wrap=�6_   $	��Top=�6s   $	��128��6�   $��1��6�   �� 5   
   -   5        $ lblGuvenlik��5      $��Güvenlik Sorusu :��6%   $
��Left=�6A   $��30��6\   $��	46,84,0,0q�6h   $	��Top=�6{   $	��127��6�   $
��Bold"�6�   $��Italic$�6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   $��1��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.708Q�6&   T� 5      5      5      �� 5    
   -   5        $ txtCevap��5       $
��Left=�6$   $��25��6?   $��174,118,0,0q�6K   $
	 Wrap=�6`   $	��Top=�6t   $	��128��6�   $��1��6�   �� 5!   
   -   5        $ lblCevap��5!      $��Cevap :��6"   $
��Left=�64   $��30��6O   $��
49,118,0,0q�6[   $	��Top=�6o   $	��127��6�   $
��Bold"�6�   $��Italic$�6�   $��1��6�   �� 5"   
   -   5         ��Name$ cmbGuvenlikSorusu��5"      $
��Left=�6.   $��25��6I   $��
174,86,0,0q�6U   $	��Top=�6i   $	��128��6�   $��1��6�   �� 5#   
   -   5         ��Name$ image��5#      $
��Left=�6   $	��216��6:   $��
302,21,0,0q�6G   $	��Top=�6[   $	��198��6s   $��sifremiUnuttum.png��6   $��1��6�   �� 5$   
   -	   5         ��Name$ 	btn_Email��5$      $��174,85,210,0q�6$   $	��Top=�6:   $
��Bold"�6R   $��Italic$�6d   $��E-mailime Yolla��6w   $��1��6�    J� IsHitTestVisible . 6�   �� 5%   
   -
   5        $ btn_Guvenlik��5%      $
��Left=�6'   $��174,153,0,0q�6B   $	��Top=�6W   $	��135��6o   $
��Bold"�6{   $��Italic$�6�   $��22��6�   $��Güvenlik Sorusu İle��6�   $��1��6�    . 6�   	� 5&   
   -   5         	�Name$	 rd1��5&      $��
Email İle��6#   $��1��67   $
��Left=�6G   $��	54,21,0,0q�6b   $	��Top=�6u   6�   	� 5'   
   -   5        $	 rd2��5'      $��Güvenlik Sorusu İle��6#   $��1��6A   $
��Left=�6Q   $��
163,21,0,0q�6l   $	��Top=�6�    d� 	IsChecked$
 TrueY�6�   6�   5)      5*      