   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:project.MVVM.Viewproject.MVVM.View  5      '    !project.MVVM.View.StudentExamView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:project.MVVM.View     5      -   5        .��5	      ��   �� Orientation$  
Horizontal=�6   .+�5
      �� $	��700��6   $	��440��6!   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,2&�6;   .��5      �  � Color$ #844eff��6'    � Offset$	 0.0Q�67   � 5      $ #ffb73a��6'   $ 1Q�67   5       J� Clip 5      �� 5       �� RadiusX$ 10Q�6(    �� RadiusY$ 10Q�5   (    �� Rect$ 0,0,695,440�5   (   ._�5      � .+�5      �� $  
Horizontal=�6   $
��Left=�66   $	��Top=�6Q   .+�5      �� -   5        	 ��Name$	 
tbExamName��5       $��15(�64   5      �� 5      $  
Horizontal=�6   $��Center=�66   $	��Top=�6S   .+�5      �� -   5        $	 
GradeBlock��5       $��15(�64   5      �� 5      $  
Horizontal=�6   $��Right=�66   $	��Top=�6R   .+�5      �� -   5        $	 tbTimer��5       $��15(�61   $��Time Remaining: 00:00��6?   $��0,0,10,0q�6\   5       �� 5!      $  
Horizontal=�6   $	��400��66   .+�5"      � $	��150��6   .+�5#      �� -   5        $��listBoxQuestions��5#   �   ���#353340$��3��6;   $��5q�6I   $��Stretch=�6�   6�   5$      � 5%      $��1��6   $��0��6/   $	��500��6<   
 � RowDefinitions
 5&      �� 5'   "   $��20 �60   �� 5(   "   $
��auto �61   �� 5)   "   $
��auto �60   �� 5*   "   $
��auto �60   �� 5+   "   $
��auto �60   �� 5,   "   $
��auto �60   �� 5-   "   $��* �60   .+�5/      �� -   5        $	 
tbQuestion��5/   (   $
��Wrap=�6<   $��0,0,0,10q�6P   $��1��6b   	� 50      -   5         	�Name$ 	rbChoiceA��50   &    	� 	GroupName$ AnswerGroup��69   $��2��6�    d� 	IsChecked 6Q   �� *IsrbChoiceAChecked+ �� Mode$ TwoWay=�6�   	� 51      -   5        $ 	rbChoiceB��51   &   $ AnswerGroup��69   $��3��6�    6Q   �� *IsrbChoiceBChecked+$ TwoWay=�6�   	� 52      -	   5        $ 	rbChoiceC��52   &   $ AnswerGroup��69   $��4��6�    6Q   �� *IsrbChoiceCChecked+$ TwoWay=�6�   	� 53      -
   5        $ 	rbChoiceD��53   &   $ AnswerGroup��69   $��5��6�    6Q   �� *IsrbChoiceDChecked+$ TwoWay=�6�   �� 54      -   5        $��50��54       $��6��55       $��Bottom=�56       $
��Left=�57       $��10,0,0,0q�58       $��50��59        � ToolTip$ Previous��5:        � Cursor$
 Hand��5;       $��/Images/previous.png��5<        �� BitmapScalingMode$
 Fant=�5=       5>       �� 5?      -   5        $��50��5?       $��6��5@       $��	280,0,0,0q�5A       $��50��5B       $
 Hand��5C       $
 Next��5D       $��/Images/next.png��5E       $
 Fant=�5F       $��Right=�5G       $��Bottom=�5H       5I       5J      5K      5L      5M      5N      5O      