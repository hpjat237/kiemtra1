   M S B A M L   `   `   `  ����J  FEssayManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EssayManagement.Views.User_Control"EssayManagement.Views.User_Control  5      3    -EssayManagement.Views.User_Control.UCThongTin   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      <local0clr-namespace:EssayManagement.Views.User_Control  5      .��5
      �� 
�������  �� CornerRadius$  20��6    $	��300��62   $	��700��6?   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��1* �6#   60   �� 5      $��1* �6#   60   .+�5      � $��0��6   .+�5      �� -   5         ��Name$ 	txtMaGVSV��5      $��Bahnschrift)�6-      TextBoxExtend#��[  6F   (  "HandyControl.Controls.TitleElement   TitlePlacement$
 Left=�6m      
TitleWidth$ 80 �6�      Title$ MSSV/GV��6�   $	��Top=�6�   $��
20,35,20,0q�6�    �� 
IsReadOnly$
 True��6�   �� 5      -   5        $ txtHoTen��5      $��Bahnschrift)�6,   #��[  6E   $
 Left=�6l   $ 80 �6�   $ Họ và tên��6�   $	��Top=�6�   $��
20,90,20,0q�6�   $
 True��6�   �� 5      -   5        $ 	txtDiaChi��5      $��Bahnschrift)�6-   #��[  6F   $
 Left=�6m   $ 80 �6�   $ Địa chỉ��6�   $	��Top=�6�   $��20,145,20,0q�6�   ${�False��6�   �� 5      -   5        $ txtCMND��5      $��Bahnschrift)�6+   #��[  6D   $
 Left=�6k   $ 80 �6�   $
 CMND��6�   $	��Top=�6�   $��20,200,20,0q�6�   5      � 5      $��1��6   .+�5      �� -   5         ��Name$ btnExit��5      $��22��6*   $��22��65   $��hc:ControlCommands.Close��6A     
ButtonIcon#��[ 6d     PrimaryBrush#���  6�     ErrorGeometry'  !HandyControl.Controls.IconElement   Geometry# [ 6�   $��0q�6�   $��Right=�6�   $	��Top=�6  $��	0,10,10,0q�6-  (  "System.Windows.Controls.DatePicker  5      -   5        	  Name$	 
dpNgaySinh��5      $��Bahnschrift)�61     DatePickerExtend#��[ 6J   $
 Left=�6t   $ 80 �6�   $ 
Ngày Sinh��6�   $	��Top=�6�   $��
20,37,20,0q�6�   �� 5      -   5        $ txtEmail��5      $��Bahnschrift)�6,   #��[  6E   $
 Left=�6l   $ 80 �6�   $ Email��6�   $	��Top=�6�   $��
19,91,21,0q�6�   �� 5      -   5        $ txtSDT��5      $��Bahnschrift)�6*   #��[  6C   $
 Left=�6j   $ 80 �6�   $ Số điện thoại��6�   $	��Top=�6�   $��20,145,20,0q�6�   �� 5      -	   5        $ btnLuu��5      $��Bahnschrift)�6)     ButtonPrimary#��[ 6B   $
��Lưu��6i   $��Right=�6w   $��	0,0,20,20q�6�   $��Bottom=�6�   $��80��6�   $
��Bold"�6�   6�   5      5      5       5!      