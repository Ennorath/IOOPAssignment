   M S B A M L   `   `   `  ���� L  HAPUIOOPAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:APUIOOPAssignmentAPUIOOPAssignment  &     APUIOOPAssignment.RegisterWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:APUIOOPAssignment       � Title$  RegisterWindow�� � 
ResizeMode$ NoResize=�$	��520��$	��960�� � 	Resources    TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxStyle1 �� 
TargetType �� Property �� Value-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name	 J� SnapsToDevicePixels
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value  FocusVisual �� StrokeDashArray  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border 	 Button.Pressed.Background 
 Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  ButtonStyle1 ��Name��%  &	        &	      &	 *     &	 ?     7   7  7  &	 f    &	 �    &	 �    &	 �    &	 �    &		     &	
     &	 2    &	 G    &	 \    &	 q    7  7  7  7  7  7 	 7 
 7  7  7  �� $ 	#FFABAdB3���� $ 	#FF7EB4EA���� $ 	#FF569DE5���� " ��.���  � ��# � ����  � ��8   ��  � ��# � ����  � ��$ 1q���  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $ border��#��z��#��z��#��z��	 . $
 8��._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border��8   � ��P�  �@J�IsKeyboardFocused . . ��� $ border��8   � �� ]�  �� + �@��#IsInactiveSelectionHighlightEnabled . ��  �@��IsSelectionActive .  ./���  �@��SelectionBrush# � /��� .���  � �� �� .R��� $��2q�	 . #��� ��$��1��$	 1 2R��� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��	 . $
 8��._��� $ contentPresenter��|�.  #��z��#��z����. #	 z	 #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border��8   � ���� $ border��8   � ��P�  � �� . . ��� $ border��8   � ���� $ border��8   � ��P�  � {� .  . ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ��.���  � ColumnDefinitions �� $
��180* ��� $
��773* �.+�� 
������� J� RenderTransformOrigin$ 0.491,0.521&�$��2��$��0,0,-0.4,0.4q�.+��� $��images\RegisterPic.jpg��$	��520��$��462,0,-130,0q�$	��Top=��� $��   Member
Registration��$
��Left=�$��
336,52,0,0q�$	��Top=�$��Berlin Sans FB)�$��36(��� $��Clubs and Activities��$
��Left=�$��
70,123,0,0q�$	��Top=�$��Berlin Sans FB)�$��24(�$ 1.003,0.226&��� $��First name:��$
��Left=�$��
79,178,0,0q�$	��Top=�$��Berlin Sans FB)�$��18(��� $��Surname:��$
��Left=�$��
85,213,0,0q�$	��Top=�$��Berlin Sans FB)�$��18(��� $��Images/APULogo.png��$��59,10,671,363q��� $��Email:��$
��Left=�$��110,248,0,0q�$	��Top=�$��Berlin Sans FB)�$��18(��� $��Student TP:��$
��Left=�$��
70,283,0,0q�$	��Top=�$��Berlin Sans FB)�$��18(��� $��	Password:��$
��Left=�$��
82,318,0,0q�$	��Top=�$��Berlin Sans FB)�$��18(��� $��    Repeat 
Password:��$
��Left=�$��
82,345,0,0q�$	��Top=�$��Berlin Sans FB)�$��18(��� -    ��Name$ FirstNameBox��$
��Left=�$��24��$��182,184,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��335��$��Berlin Sans FB)�$��20(�#���  �� -   $ 
SurnameBox��$
��Left=�$��24��$��182,219,0,0q�$
 Wrap=�$	��Top=�$	��335��$��Berlin Sans FB)�$��20(�#���  �� -   $ EmailBox��$
��Left=�$��24��$��182,254,0,0q�$
 Wrap=�$	��Top=�$	��335��$��Berlin Sans FB)�$��20(�#���  �� -   $ StudentTPBox��$
��Left=�$��24��$��182,289,0,0q�$
 Wrap=�$	��Top=�$	��335��$��Berlin Sans FB)�$��20(�#���  G� -    G�Name$ PasswordBox��$
��Left=�$��24��$��182,324,0,0q�$	��Top=�$	��335��$��Berlin Sans FB)�$��20(�G� -   $ RPasswordBox��$
��Left=�$��24��$��182,366,0,0q�$	��Top=�$	��335��$��Berlin Sans FB)�$��20(��� -    ��Name$ RegisterBtn��$��Register��$
��Left=�$��
97,421,0,0q�$	��Top=�$	��143��$��53��$��36(�$��Berlin Sans FB)����	#FFF15B5B#���  �� -   $ LoginBtn��$��	Log in ->��$
��Left=�$��412,427,0,0q�$	��Top=�$	��105��$��36��$��22(�$��Berlin Sans FB)�
�������#���  
���   �
�������