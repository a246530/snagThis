   M S B A M L   `   `   `  ����C  ?snagThis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:snagThissnagThis  5   	       snagThis.hud   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   "localclr-namespace:snagThis  5   	   -   5           MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5	   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � Title$	 hud��5   	   $	��533��6   $��712.95��6"    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62   .��5      � .+�5   
   �� 
���   �$��1q�6%   $��0,0,0,0q�69   �� 5   
   -   5         ��Name$ closeWindowButton��5      $
��Left=�6,   $��	689,7,0,0q�6G   $	��Top=�6Z   $��17��6r   $��17��6}   $��0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowClose=�6&   $��Center=�69   $��14��6T   5      �� 5   
   -   5         ��Name$ screenShotHolder��5      $	��400��6*   $	��Top=�69   $��0,40,0,0q�6Q   �� 5   
   -   5        $
 save��5      $
��Left=�6    $��116,458,0,0q�6;   $	��Top=�6P   $	��111��6h   $��35��6t   .��5      �� 	 �� Orientation$	 
Horizontal=�6   .+�5        $ ContentSave=�6*   $��Center=�6>   �� 5      $��Center=�6   .��63   Save69   5      5      �� 5   
   -   5        $ saveas��5      $
��Left=�6"   $��233,458,0,0q�6=   $	��Top=�6R   $	��111��6j   $��35��6v   .��5       �� $	 
Horizontal=�6   .+�5!        $ ContentSaveSettings=�6*   $��Center=�6E   �� 5"      $��Center=�6   .��63   	Save As6<   5#      5$      �� 5%   
   -   5        $ copyToClipboard��5%      $
��Left=�6*   $��350,458,0,0q�6E   $	��Top=�6Z   $	��125��6r   $��35��6~   .��5&      �� $	 
Horizontal=�6   .+�5'        $ ClipboardText=�6*   $��Center=�6@   �� 5(      $��Center=�6   .��63   	Clipboard6>   5)      5*      �� 5+   
   -   5        $ email��5+      $
��Left=�6    $��482,458,0,0q�6;   $	��Top=�6P   $	��125��6h   $��35��6t   .��5,      �� $	 
Horizontal=�6   .+�5-        $ EmailOutline=�6*   $��Center=�6?   �� 5.      $��Center=�6   .��63   Email6:   5/      50      54      55      