   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:projectproject  5   	   ?$clr-namespace:project.MVVM.ViewModelproject.MVVM.ViewModel  5   	       project.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:project     5   	   :	viewModel$clr-namespace:project.MVVM.ViewModel     5   	   $	��600��5	   	   $	��920��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�6#    � DataContext 5      *  $project.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 30��5      ._�5   
   � -   5         � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��75 �6    �� 5      .+�5      �� $��
TestSystem��6   $��Center=�5       $
��left=�5!      
�������$��22(�5#      $��20,0,0,0q�5$      $��/Fonts/#Poppins)�5%      �� 5'      $��1��6   .+�5(      	� -   5         	�Name$ btnHome��5(      $
��Home��5)      $��50��5*      
�������$��14(�5,         MenuButtonTheme#��[  5-      	 d� 	IsChecked$
	 TrueY�5.      $��/Fonts/#Poppins)�50      ��5/      �� *HomeViewCommand+50      	� 51      -   5        $ 
btnTeacher��51      $��Teacher��52      $��50��53      
�������$��14(�55      #��[  56      $
	 TrueY�58      $��/Fonts/#Poppins)�5:      y�57      �� *IsTeacherButtonVisiable+��59      �� *TeacherViewCommand+5:      	� 5<      -   5        $ 
btnStudent��5<      $��Student��5=      $��50��5>      
�������$��14(�5@      #��[  5A      $
	 TrueY�5C      $��/Fonts/#Poppins)�5E      y�5B      �� *IsStudentButtonVisiable+��5D      �� *StudentViewCommand+5E      5F      �� 5G      -   5        
 ��Name$
 loginBtn��5G      $	��100��5H      $��LOGIN��5I      $��18(�5J      $��/Fonts/#Poppins)�5K      $��40��5L      $��Center=�5M      $��Right=�5N      $��1��5O       � Cursor$
 Hand��5P      $��0,0,20,0q�5Q      y�5R      �� *IsTeacherButtonVisiable+��5S      �� *LoginViewCommand+�� 5T      $��1��6   $��1��5U      $��
6,10,14,10q�5V      ��5W      �� *CurrentView+5X      5Z      5[      