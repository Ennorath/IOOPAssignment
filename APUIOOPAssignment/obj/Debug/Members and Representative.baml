   M S B A M L   `   `   `  ����L  HAPUIOOPAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:APUIOOPAssignmentAPUIOOPAssignment  5   	   2    ,APUIOOPAssignment.Members_and_Representative   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:APUIOOPAssignment     5   	     � Title$   Members_and_Representative��5   	   $	��700��6,   $	��692��69    � 	Resources 5	         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle2 �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%I  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $	 border��6!   #��z��61   #��z��6]   #��z��6�    . $
 8��6�   ._�5)      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted . . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver . . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � �� . . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {� .  . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5B      �� .��5C   
   � -   5         �Name$ memberListGrid��5C      .+�5D      �� $
��Left=�6   $��73��6/   $	��Top=�6;   $	��686��6S   $��Images\BG up.jpg��6_   �� 5E      $
��Left=�6   $��64��6/   $��0,73,0,0q�6;   $	��Top=�6M   $	��686��6e   $*��$Images\Club representative BG UP.jpg��6q   �� 5F      $
��Left=�6   $��61��6/   $��	0,136,0,0q�6;   $	��Top=�6N   $	��686��6f   $!��Images\configure status.jpg��6r   �� 5G      -   5         ��Name$ 	txtSearch��5G      $
��Left=�6)   $��19��6D   $��379,156,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��233��6�   $��Berlin Sans FB)�6�   $��18(�6�   �� 5H      -   5         ��Name$ 	btnSearch��5H      $
��Left=�6(   $��613,155,0,0q�6C   $	��Top=�6X   $��38��6p   $��19��6{   ���#289cff.��5I      �� .+�5J      �� $��Images\search.png��6   $��18��67   $��20��6C   5L      5M      �� 5N      $
��Left=�6   $��0,197,-0.4,0q�6/   $	��Top=�6E   $	��686��6]   $��Images\bg blue light.jpg��6i   $
��Fill=�6�   �� 5P      -   5         ��Name$ 
memberList��5P      $	��Top=�6-   $��Center=�6E   $��	0,260,0,0q�6b   $	��572��6u   $
��Auto��6�   5R      �� 5T      -   5         ��Name$ lblClubName��5T      $
��Left=�6)   $��222,213,0,0q�6D   $	��Top=�6Y   $	��249��6q   $��Center=�6~   $��Berlin Sans FB)�6�   $��20(�6�   �� 5U      -   5        $ btnBack��5U      $
��Left=�6&   $��	27,83,0,0q�6A   $	��Top=�6T   $��75��6l   $��38��6w   ���#c0c0c0$��0q�6�   .��5V      �� .+�5W      �� $��Images\Back button.png��6   $��36��6<   $��50��6H   5Y      5Z      5[      5\      5]      