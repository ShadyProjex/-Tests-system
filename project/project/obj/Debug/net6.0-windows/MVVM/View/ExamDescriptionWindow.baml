   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:project.MVVM.Viewproject.MVVM.View  5   	   ?$clr-namespace:project.MVVM.ViewModelproject.MVVM.ViewModel  6n   -    'project.MVVM.View.ExamDescriptionWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:project.MVVM.View     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  67   4	viewModel$clr-namespace:project.MVVM.ViewModel  6n     � Title$  ExamDescriptionWindow��5   	   $	��500��6'   $	��400��64    � WindowStyle$
 None=�5	   	   
������  � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�6#   .��5      �� ���#272537 �� CornerRadius$ 30��5   	   ._�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $
��auto �6!   �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��/Fonts/#Poppins)�6   $��15(�61   
�������$��10q�6R   $��1��6^   $
��Name��6l   $
��Left=�6{   �� 5      -   5         ��Name$ examNametxt��5      $��1��5      $	��300��5      $��60,0,0,0q�5         ModernTextBox#��[  5       ��5      �� *ExamNameTextValue+ �� UpdateSourceTrigger$ PropertyChanged=�5       �� 5!      $��/Fonts/#Poppins)�6   $��15(�61   
�������$��10q�6R   $��2��6^   $��Teacher��6l   $
��Left=�6~   �� 5"      -   5        $ teacherNametxt��5$      $��2��5"      $	��300��5#      $��60,0,0,0q�5%      #��[  5'      ��5&      �� *TeacherNameTextValue+$ PropertyChanged=�5'      �� 5(      $��/Fonts/#Poppins)�6   $��15(�61   
�������$��10q�6R   $��3��6^   $��Duration��6l   $
��Left=�6   �� 5)      -   5        $ durationtxt��5,      $��3��5)      $	��300��5*      	 � ToolTip$	 
in Minutes��5+      $��60,0,0,0q�5-      #��[  5/      ��5.      �� *DurationTextValue+$ PropertyChanged=�5/      �� 50      $��4��6   
 �� Orientation$
 
Horizontal=�6&   .+�51      �� $��/Fonts/#Poppins)�6   $��15(�65   
�������$��10q�6V   $��4��6b   $��isRandomise��6p   $
��Left=�6�   	� 52      -   5         	�Name$ isYesButton��52      $��/Fonts/#Poppins)�63   $��5q�6P   $��Center=�6[   $��Center=�53      .��69   Yes6>   	� 54      -   5        $ 
isNoButton��54      $��/Fonts/#Poppins)�62   $��Center=�6O   $��Center=�55      .��69   No6=   56      &   Xceed.Wpf.Toolkit.DateTimePicker  57      -   5          Name$ DateTimepicker��57   "   $
��Auto��58   "   $��5��59   "   $��Center=�5:   "   $��15(�5;   "   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5<   "      FormatString$ dd MMMM yyyy hh:mm tt��5=   "      AutoCloseCalendar$
 True��5>   "   
��������  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   ClipValueToMinMax$
 True��5@   "      
TimeFormat$ Custom=�5A   "      TimeFormatString$ hh:mm��5B   "   
������ 5C   "   �� 5D      $��6��6   $	��150��6&   $	��400��63   $
 
Horizontal=�6?   .+�5E      �� -   5        $��50��5E      $��Center=�5F      $
��Left=�5G      $��10,0,0,0q�5H      $��50��5I      $
	 Back��5J       � Cursor$
 Hand��5K      $��/Images/back.png��5L       �� BitmapScalingMode$
 Fant=�5M      5N      �� 5O      -   5        $��50��5O      $��	280,0,0,0q�5P      $��50��5Q      $
 Hand��5R      $	 Apply��5S      $��/Images/apply.png��5T      $
 Fant=�5U      $��Right=�5V      $��Center=�5W      5X      5Y      5Z      5[      5\      