   M S B A M L   `   `   `  ����C  ?snagThis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:snagThissnagThis  5   	       snagThis.settings   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:snagThis     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5           MaterialDesignBody#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � Title$ Settings��5   	   $	��506��6   $	��700��6'    � WindowStartupLocation$ CenterScreen=�63    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      � .+�5   
   �� -   5         ��Name$ closeWindowButton��5      $
��Left=�6,   $��	680,6,0,0q�6G   $	��Top=�6Z   $��14��6r   $��14��6}   $��0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�6&   $��Center=�69   $��14��6T   5      �� 5   
   $��Settings��6   $��32(�6#   $
��Left=�61   $��0,25,0,0q�6L   $	��Top=�6^   $	��700��6v   �� 5   
   $��Dark Or Light Mode��6   $
��Left=�6-   $��	51,86,0,0q�6H   $	��Top=�6[   $	��144��6s   �� 5   
   -   5         ��Name$ 
modePicker��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$
	 Mode��6'   $��57,117,499,361q�6M   
 �� SelectedValuePath$
 Content��5      .@�5      �� ���#303030���#ffffff.��6E   Dark6K   �� 5      ���#ffffff���#000000.��6E   Light6L   5      �� 5!   
   $��Primary Color:��6   $
��Left=�6)   $��
265,86,0,0q�6D   $	��Top=�6X   $	��144��6p   �� 5"   
   -   5        $ PrimaryColorPicker��5"      $	 Primary Color��6/   $��265,117,291,361q�6^   $
 Content��5#      .@�5$      �� ���#F44336.��60   Red65   �� 5%      ���#E91E63.��60   Pink66   �� 5&      ���#9C27B0.��60   Purple68   �� 5'      ���#673AB7.��60   
DeepPurple6<   �� 5(      ���#3F51B5.��60   Indigo68   �� 5)      ���#2196F3.��60   Blue66   �� 5*      ���#03A9F4.��60   	LightBlue6;   �� 5+      ���#00BCD4.��60   Cyan66   �� 5,      ���#009688.��60   Teal66   �� 5-      ���#4CAF50.��60   Green67   �� 5.      ���#8BC34A.��60   
LightGreen6<   �� 5/      ���#CDDC39.��60   Lime66   �� 50      ���#FFEB3B.��60   Yellow68   �� 51      ���#FFC107.��60   Amber67   �� 52      ���#FF9800.��60   Orange68   �� 53      ���#FF5722.��60   
DeepOrange6<   �� 54      ���#795548.��60   Brown67   �� 55      ���#9E9E9E.��60   Grey66   �� 56      ���#607D8B.��60   
BlueGrey6:   57      �� 5:   
   $��Accent Color:��6   $
��Left=�6(   $��
456,86,0,0q�6C   $	��Top=�6W   $	��144��6o   �� 5;   
   -   5        $ AccentColorPicker��5;      $	 Accent Color��6.   $��462,117,94,361q�6\   $
 Content��5<      .@�5=      �� ���#F44336.��60   Red65   �� 5>      ���#E91E63.��60   Pink66   �� 5?      ���#9C27B0.��60   Purple68   �� 5@      ���#673AB7.��60   
DeepPurple6<   �� 5A      ���#3F51B5.��60   Indigo68   �� 5B      ���#2196F3.��60   Blue66   �� 5C      ���#03A9F4.��60   	LightBlue6;   �� 5D      ���#00BCD4.��60   Cyan66   �� 5E      ���#009688.��60   Teal66   �� 5F      ���#4CAF50.��60   Green67   �� 5G      ���#8BC34A.��60   
LightGreen6<   �� 5H      ���#CDDC39.��60   Lime66   �� 5I      ���#FFEB3B.��60   Yellow68   �� 5J      ���#FFC107.��60   Amber67   �� 5K      ���#FF9800.��60   Orange68   �� 5L      ���#FF5722.��60   
DeepOrange6<   �� 5M      ���#795548.��60   Brown67   �� 5N      ���#9E9E9E.��60   Grey66   �� 5O      ���#607D8B.��60   
BlueGrey6:   5P      �� 5S   
   $$��Default Saved Picture Location��6   $
��Left=�69   $��
51,197,0,0q�6T   $	��Top=�6h   �� 5T   
   -   5         ��Name$ saveFolderPath��5T      $
��Left=�6*   $��29��6E   $��
57,228,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $
��Path��6y   $	��Top=�6�   $	��423��6�   �� 5U   
   -   5        $ SelectDefaultSaveLocation��5U      $��Select Folder��64   $
��Left=�6L   $��491,228,0,0q�6g   $	��Top=�6|   $	��115��6�   6�   �� 5W   
   $��
Auto Focus��6   $
��Left=�6%   $��
52,302,0,0q�6@   $	��Top=�6T   $��79��6l   �� 5X   
   $��58,328,549,157q�6    �� Orientation$ 
Horizontal=�6-   .+�5Y      	� -   5         	�Name$ AutoFocusTrue��5Y      $	��Yes��62   $
��Left=�6@   $	��Top=�6\   6t   	� 5Z      -	   5        $ AutoFocusFalse��5Z      $��No��62   $
��Left=�6?   $	��Top=�6Z   6r   5[      �� 5\   
   $S��M*When you hover over a window it will bring it in front of all other screens.��6   $
��Left=�6h   $��131,304,0,0q�6�   $	��Top=�6�   $
��11px(�6�   5`      5a      