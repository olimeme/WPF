   M S B A M L   `   `   `  ����O  KProgressBarDarkTheme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ProgressBarDarkThemeProgressBarDarkTheme  5   	   %    ProgressBarDarkTheme.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ProgressBarDarkTheme     5   	     � Title$  
MainWindow��5   	   $	��237��6   $	��300��6)    � 	Resources 5	         ProgressBar.Progress �� Color  ProgressBar.Background  ProgressBar.Border �� 
TargetType �� Property �� Value �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle��%�  &	        &	 #     &	 F     '� i     7   7  7  �� 5
   
   $ 	#FF06B025��67   �� 5   
   $ 	#FFE6E6E6��69   �� 5   
   $ 	#FFBCBCBC��65   �� 5   
   " �6   .�5      ��  � ��8   6+   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��$ 1q�60   �� 5       � �� 5      �� 5      " �6&   .R�5      � $ TemplateRoot��6    5        5   "   CommonStates��.	 5   &     Determinate��62     5   &   Indeterminate��.
 5   *   �� $ Forever��65   .��5   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   $ 	Animation��6�   .\�5   2     $ 0��6G   $
 0.25Q�6S     5   2   $ 0:0:1��6G   $
 0.25Q�6W     5   2   $ 0:0:2��6G   $
 0.25Q�6W   5   /   *� 5    .   $' !(UIElement.RenderTransformOrigin)�6K   $ 	Animation��6�   .'�5!   2     $ 0��6F   $ -0.5,0.5&�6R     5"   2   $ 0:0:1��6F   $ 0.5,0.5&�6V     5#   2   $ 0:0:2��6F   $ 1.5,0.5&�6V   5$   /   5%   +   5&   '   5'   #   .+�5)      �� #��z��6%   #��z��6Q   #��z��6�   �� 5*      $ 
PART_Track��6(   ���	#FF7070706<   � 5+      $ PART_Indicator��6#   }�. $
��Left=�6O   .+�5,   "   �� $ 	Indicator��6,   #��z��6?   �� 5-   "   $ 	Animation��6,   $ 0.5,0.5&�6?   ���	#FF9B9B9B6_   5.      5/       50      P� 51       �@�Orientation$ Vertical=�6=   . �52   "   �� $ TemplateRoot��6D    �@�LayoutTransform 53   &   �� 54   *   $	 -90Q�6:   56   #   57      P� 58       �@�IsIndeterminate . . �59   "   �� $ 	Indicator��6?    � y�$ 	Collapsed=�6V   5:      5<      5>      5?      5@      .��5A      � ���	#FF343434 � RowDefinitions 5B   
   �� 5C      $��* �6   �� 5D      $
��Auto �6   �� 5E      $
��Auto �6   �� 5F      $��10 �6   �� 5G      $
��Auto �6   �� 5H      $��* �6   .+�5J   
   � -   5        $��TestProgressBar��5K      $��5��5J      $��20��5L      $ 0.5,0.5&�6"   $��19,16,21,39q�6B   z�5M      V� 5N      .~�5O      �� �� 5P       �� AngleX$ -17.876Q�6$   �� 5Q      T� 5R       T� X$ 3.225Q�6)   5S      5U      �� 5V   
   -   5        $��ProgressTextBlock��5X      $��2��5V      $��Center=�5W      
�������$��Segoe UI Light)�5X   @   $��20(�6\   �� 5Y   
   -   5        $��DoWorkButton��5Z      $��Do Work��5[      $��98,0,108,43q�6>   $��29��6S   $��Bottom=�6_   5\      5]      