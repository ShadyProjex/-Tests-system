   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:project.MVVM.Viewproject.MVVM.View  5      ?$clr-namespace:project.MVVM.ViewModelproject.MVVM.ViewModel  6<   #    project.MVVM.View.StudentView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:project.MVVM.View     5      :	viewModel$clr-namespace:project.MVVM.ViewModel     6<     � DataContext  5	      *  $project.MVVM.ViewModel.MainViewModel  5
   
   .��5      �� .+�5   
   �� $��Hello Student!��6   
�������$��28(�5      $
��left=�5      $��0,0,0,20q�5      $��/Fonts/#Poppins)�5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $	��350��6   $	��200��5      ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,2&�6;   .��5      �  � Color$ #4eff91��6'    � Offset$	 0.0Q�67   � 5      $ #ffb73a��6'   $ 1Q�67   5       J� Clip 5      �� 5       �� RadiusX$ 10Q�6(    �� RadiusY$ 10Q�5   (   	 �� Rect$	 0,0,350,200�5    (   ._�5#      � .+�5$      �� .+�5%      �� $(��"Enter your exam
identifer to start��6$   
�������$��28(�5'   $   $
��Left=�5(   $   $��
20,10,10,0q�5)   $   $	��310��68   $��/Fonts/#Poppins)�5*   $   �� 5+      $ 
Horizontal=�6%   .+�5,      �� $
��Left=�6&   $��10,10q�5-   &      ModernTextBox#��[  5/   &   $	��200��50   &   ��5.   &   �� *DataContext.SearchBoxText+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� RelativeSource ��  �� AncestorType" �50   &   �� 51      -   5         ��Name$ StartButton��51   %   $��Start��52   %   
�������$
��Left=�54   %   $��10,0,0,0q�56   %   $��Center=�57   %   ��55   %   �� *" DataContext.StartExamViewCommand+ �� " ���58   "   �� 59   &    �� 
TargetType" ��6,   .�5:   *   ��  �� Property � �� �� Value$ /Fonts/#Poppins)�6S   �� 5;   *    �@�Cursor$
 Hand��6C   �� 5<   *    � �� �#fe65846G   5=   '   ��5@   "   �� 5A   &    �� 
TargetType" ��66   .R�5B   *   �� $��80��61   $��25��5C   1    �� CornerRadius$ 10��5D   1   #��z��5E   1   ._�5G   .   �� $��Center=�6?   $��Center=�5H   ?   5I   +   5J   '   5L      5M      5N      5O      5P      �� 5Q      $ Vertical=�6   .+�5R      �� $	��300��6   $	��200��5S      $ 10��5T      $��45,0,0,0q�5U      ��5W      �� 5X      $	 0,0&�6.   $	 1,2&�6?   .��5Y      � $ #844eff��6+   $	 0.0Q�6;   � 5Z      $ #ffb73a��6+   $ 1Q�6;   5[      ._�5]      �� $	��300��6   $	��300��5^      $��/Images/bstoflk.png��5_       �� BitmapScalingMode$
 Fant=�5`      $��Center=�5a      $��Center=�5b      5c      5d      5f      5g      5h      