   M S B A M L   `   `   `  ����D  @Animation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Animation	Animation  5          Animation.Options   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Animation     5      -   5        .��5	      �� ���#393939.+�5
   
   � -   5          �Name$  progress��5
      $	��265��6(    �� Left$ 10��64   
 �� Top$ 20��6E   $��30��6U    � Maximum$ 3Q�6a    � Minimum$ 1Q�6m    � Value$ 2Q�6y   
������ 6�   �� 5   
   -   5         ��Name$ slider��5      $ 10��6!   $ 25��62   $	��265��6B   $ 3Q�6N   $ 2Q�6Z    � SmallChange$ 1Q�6d   $ 1Q�6t   6�   �� 5   
   $
��Easy��6   ���#FC1778$��20(�65   $ 10��6C   $ 61��6T   �� 5   
   $��Normal��6   ���#FC1778$��20(�67   $	 112��6E   $ 61��6W   �� 5   
   $
��Hard��6   ���#FC1778$��20(�65   $	 237��6C   $ 61��6U   �� 5   
   $��	Shoot Key��6   ���#FC1778$��20(�6:   $ 10��6H   $	 148��6Y   �� 5   
   -   5         ��Name$ txt_shoot_key��5      $��39��6)   $	 119��65   	 �� TextWrapping$
	 Wrap=�6G   $��25(�6[   $	 143��6i   $	��156��6z   
 �� 
IsReadOnly
 . 
������ ���#FC1778$
��Bold"�6�   �� 5   
   -   5         ��Name$ btn_back��5      $��	     Back��6#   
�������$��25(�6J   $	��100��6X   $	 238��6d    � Cursor$
 Hand��6u   ��5      �� 5       �� ImageSource$ img/back.png��6    j� 
AlignmentX$
 Left=�68    j� Stretch$ Uniform=�6J   5      �� 5   
   -   5        $ btn_save��5      $��	     Save��6#   
�������$��25(�6J   $	��100��6X   $	 185��6d   $	 238��6v   $
 Hand��6�   ��5      �� 5      $ img/diskette.png��6   $
 Left=�6<   $ Uniform=�6N   5      �� 5   
   -   5        $ spaceKey��5      $��Default��6#   $	 119��65   $	 187��6G   $	��156��6X   $��16(�6d   $
��Bold"�6r   ���#FC1778���#282828$
 Hand��6�   6�   5      5       