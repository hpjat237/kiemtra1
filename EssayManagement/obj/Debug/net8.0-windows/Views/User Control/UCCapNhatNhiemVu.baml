   M S B A M L   `   `   `  ����J  FEssayManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EssayManagement.Views.User_Control"EssayManagement.Views.User_Control  5      9    3EssayManagement.Views.User_Control.UCCapNhatNhiemVu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      <local0clr-namespace:EssayManagement.Views.User_Control  5      .��5
      �� 
�������  �� CornerRadius$  20��6    ._�5   
   �  � RowDefinitions 5      �� 5      $��5* �6    6.   �� 5      $��1* �6    6.   .+�5      � $��0��6   .+�5      �� -   5         ��Name$ btnExit��5      $��22��6*   $��22��65   $��hc:ControlCommands.Close��6A      
ButtonIcon#��[  6d     PrimaryBrush#���  6�     ErrorGeometry'  !HandyControl.Controls.IconElement   Geometry# [ 6�   $��0q�6�   $��Right=�6�   $	��Top=�6  $��	0,10,10,0q�6-  �� 5      -   5         ��Name$ 	txtTieuDe��5      $��Bahnschrift)�6-     TextBoxExtend#��[ 6F   (  "HandyControl.Controls.TitleElement   TitlePlacement$
 Left=�6m      
TitleWidth$ 85 �6�      Title$ Tiêu đề��6�   $	��Top=�6�   $��20,47,410,0q�6�   $��30��6�   $	��370��6	   �� 
IsReadOnly$
 True��6  �� 5      -   5        $ 	txtTiendo��5      $��Bahnschrift)�6-   #��[ 6F   $
 Left=�6m   $ 85 �6�   $ Tiến độ��6�   $	��Top=�6�   $��Right=�6�   $��
30,47,10,0q�6  $��30��6  $	��370��6$  $
 True��60  �� 5      -   5        $ txtMoTa��5      $��Bahnschrift)�6+   #��[ 6D   $
 Left=�6k   '  !HandyControl.Controls.InfoElement	   Placeholder$	 Mô tả��6�   $��24,100,17,113q�6�   
 �� TextWrapping$

 Wrap=�6�    J� RenderTransformOrigin$ 0.124,0.032&�6�   $	��Top=�6  $
 True��6#  �� 5      -   5        $ txtDiem��5      $��Bahnschrift)�6+   #��[ 6D   $
 Left=�6k   $ 50 �6�   $ Điểm��6�   $	��Top=�6�   $��-190,290,410,0q�6�   $��30��6�   $	��150��6  $
 True��6  �� 5      -   5        $ 
txtDanhGia��5      $��Bahnschrift)�6.   #��[ 6G   $
 Left=�6n   $	 Đánh giá��6�   $��200,290,20,20q�6�   $

 Wrap=�6�   $ 0.124,0.032&�6�   $	��Top=�6
  $
 True��6)  5      � 5      $��1��6   .+�5      �� -   5        $ txtLuu��5        ButtonPrimary#��[ 6)   $��Gửi��6P   $��Right=�6^   $��	0,0,20,20q�6z   $��Bottom=�6�   $��80��6�   $
��Bold"�6�   6�   5      5      5      5      