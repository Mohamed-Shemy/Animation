   M S B A M L   `   `   `  ����D  @Animation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Animation	Animation  5   	       Animation.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Animation     5   	   -   5          �Name$  window��5	   �    � Title$ 
MainWindow��5   	   $	��600��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�5	   x    � Icon$ wesnoth.ico��6�   ��5
      �� 5   
    �� ImageSource$ img/background.jpg��6    j� Stretch$ UniformToFill=�66   .��5      ]� -   5        .+�5   
   ]� $	��Top=�6   $��50��6)   
���   �.+�5      �� -   5        $��tb_score��5   7   $��5q�6   $
��Left=�6!   $��0��6G   $��30(�6P   
 �� Top$ 5��6^    �� Left$ 5��6m   $	��100��6}   
������� �� TextAlignment$ Center=�6�   
���   �	 �� 
IsReadOnly	 . 6�   �� 5      -   5        
 ��Name$
 btn_menu��5   ,   $��Right=�6   $��40��6?   $ 5��6J   $	 341��6Y    � Cursor$
 Hand��6k   $��40��6y   $��0q�6�    � ToolTip$
 Menu��6�   ��5      �� 5      $ img/menu.png��6!   5      � 5      -   5         �Name$
 life��5   -   $��	10,0,10,0q�6   $ 5��6;   $	 116��6J   $��40��6\    � Value$	 100Q�6h    � Maximum$	 100Q�6t   
��� � �6�   5      �� 5   
   -   5        $��
mainCanvas��5      .+�5   
   �� -   5        $��warship��5      $��68��6    $��80��6+   $	 165��67   $	 440��6I   .+�5      �� -   5        $	��gun��5      $��30��6   $��10��6+   $ 29��66   $ 2��6G   $��img/gun.png��6V   �� 5      -	   5         ��Name$ rocket��5      $
��Left=�6$   $��68��6?   $	��Top=�6K   $��68��6c   $��img/spacecraft-1.png��6n   $ 0��6�    �� Bottom$ 0��6�   5      �� 5       -
   5         ��Name$ monster��5       $	��150��6&   $	��160��62   $	 125��6?   $
 -213��6Q   .+�5!      � -   5        $��monsterLife��5!      $	��150��61   $��10��6=   $	 100Q�6I   6q   �� 5"      $
��Left=�6   $	��150��63   $	��150��6@   $��img/monster.png��6L   $ 15��6e   5#      5%      5'      5(      