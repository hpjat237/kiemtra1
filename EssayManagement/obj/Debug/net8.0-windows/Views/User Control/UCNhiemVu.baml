   M S B A M L   `   `   `  ����J  FEssayManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EssayManagement.Views.User_Control"EssayManagement.Views.User_Control  5      2    ,EssayManagement.Views.User_Control.UCNhiemVu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      <local0clr-namespace:EssayManagement.Views.User_Control  5      .��5
      �� 
�������  �� CornerRadius$  20��6    $	��585��62   $	��800��6?   $��Bottom=�6K   $��0,0,0,0q�6f   ._�5   
   �  � RowDefinitions 5      �� 5      $��8* �6    6.   �� 5      $��1* �6    6.   .+�5      �� -   5         ��Name$ btnExit��5      $��22��6&   $��22��61   $��hc:ControlCommands.Close��6=      
ButtonIcon#��[  6`     PrimaryBrush#���  6�     ErrorGeometry'  !HandyControl.Controls.IconElement   Geometry# [ 6�   $��0q�6�   $��Right=�6�   $	��Top=�6  $��	0,10,10,0q�6)  $y�Visible=�6<  �� 5      -   5         ��Name$ txtMaLuanVan��5      $��Bahnschrift)�6,     TextBoxExtend#��[ 6E   (  "HandyControl.Controls.TitleElement   TitlePlacement$
 Left=�6l      
TitleWidth$ 90 �6�      Title$ Mã luận văn��6�   $��30��6�   $	��Top=�6�    �� 
IsReadOnly$
 True��6�   $��20,20,430,0q�6	  � 5      $��0��6   $��
-3,55,-3,0q�6    .+�5      �� $	��Top=�6   $	��520��65   $��0,0,0,0q�6B   .+�5      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 
dgvNhiemVu��5      
   HeadersVisibility$
 Column=�63      RowHeaderWidth$ 60Q�6N      AutoGenerateColumns$ False��6b   $
��Bold"�6�      
IsReadOnly$
 True��6�   $��10,10,10,10q�6�   $��Bahnschrift)�6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 65      Header$ Tiêu đề��6@      CellTemplate 5   "   �� 5   &   .R�5   *   ��  ��Name$ txtTenDeTai��64   $
��Wrap=�6`   $��Normal"�6t   
���   ���6I   �� *TuaDe+6�   5   '   5        5      $ 3* 65   $ Mô tả��6@    5   "   �� 5   &   .R�5    *   �� $ txtMoTa��64   $
��Wrap=�6[   $��Normal"�6o   
���   ���6E   �� *MoTa+6�   5!   '   5#        5$      $ 2* 6   $ Nhận xét��6$    5%      �� 5&   
   .R�5'      �� $ 
txtNhanXet��6   $
��Wrap=�6E   $��Normal"�6Y   
���   ���6,   �� *	NhanXet+6m   5(      5*      0  *System.Windows.Controls.DataGridTextColumn  5+      $ 80 61   $ Tiến độ��6W      
FontWeight$ Normal"�6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *TienDo+6h     5,       5-   "   �� 5.   &   -   5          RotateRightGeometry# [ 5.   -   $��Right=�6l   $	��Top=�6�   $��60��6�   $
��Bold"�6�   6�    50   "   �� 51   &   .R�52   *   �� $ btnXemChiTiet��61   -   5        $��Xem chi tiết��52   H   $
��Bold"�6_   6q   53   '   55      57      58      59      � 5:      $��1��6   $��0,0,0,0q�6    .+�5;      �� -   5        $ txtThemTask��5;        ButtonPrimary#��[ 6.   $��
Thêm task��6U   $��Right=�6i   $��	0,0,20,20q�6�   $��Bottom=�6�   $��80��6�   $
��Bold"�6�   6�   5<      5=      5>      5?      