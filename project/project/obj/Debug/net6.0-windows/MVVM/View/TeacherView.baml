   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:project.MVVM.Viewproject.MVVM.View  5      ?$clr-namespace:project.MVVM.ViewModelproject.MVVM.ViewModel  5      #    project.MVVM.View.TeacherView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:project.MVVM.View     5      :	viewModel$clr-namespace:project.MVVM.ViewModel     5        � DataContext  5
      *  $project.MVVM.ViewModel.MainViewModel  5   
   .��5      �� .+�5   
   �� -   5         ��Name$ greetingText��5      $��Hello Teacher!��5      
�������$��28(�5      $
��left=�5      $��0,0,0,20q�5      $��/Fonts/#Poppins)�5      5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $	��350��6   $	��200��5      ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,2&�6;   .��5      �  � Color$ #4eff91��6'    � Offset$	 0.0Q�67   � 5      $ #ffb73a��6'   $ 1Q�67   5       J� Clip 5      �� 5        �� RadiusX$ 10Q�6(   	 �� RadiusY$	 10Q�5!   (   
 �� Rect$
 0,0,350,200�5"   (   ._�5%      � .+�5&      �� .+�5'      �� $&�� Search existing exam
in database��6$   
�������$��28(�5)   $   $
��Left=�5*   $   $��
20,10,10,0q�5+   $   $	��310��68   $��/Fonts/#Poppins)�5,   $   �� 5-      $ 
Horizontal=�6%   .+�5.      �� -   5         ��Name$ searchExamBox��5.   &   $
��Left=�6=   $��10,10q�5/   &      ModernTextBox#��[  51   &   $	��200��52   &   ��50   &   �� *DataContext.SearchBoxText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� RelativeSource ��  �� AncestorType" �52   &   �� 53      -   5         ��Name$ updateButton��53   %   $��update��54   %   
�������$
��Left=�57   %   $��10,0,0,0q�58   %   $��Center=�59   %   ��55   %   �� *)'DataContext.updateExamEditorViewCommand+ �� " ���5:   "   �� 5;   &    �� 
TargetType" ��6,   .�5<   *   ��  �� Property � �� �� Value$ /Fonts/#Poppins)�6S   �� 5=   *    �@�Cursor$
 Hand��6C   �� 5>   *    � �� �#fe65846G   5?   '   ��5B   "   �� 5C   &    �� 
TargetType" ��66   .R�5D   *   �� $��80��61   $��25��5E   1    �� CornerRadius$ 10��5F   1   #��z��5G   1   ._�5I   .   �� $��Center=�6?   $��Center=�5J   ?   5K   +   5L   '   5N      5O      �� 5P      -   5        $ Statisticsbtn��5P   !   $��
Statistics��5Q   !   
������� J� RenderTransformOrigin$ -1.265,1.455&�5S   4   ��5R   !   �� *,*DataContext.StatisticsDashboardViewCommand+ �� " ���5U      �� 5V   "   " ��6(   .�5W   &   ��  � ��$ /Fonts/#Poppins)�6O   �� 5X   &    �@�Cursor$
 Hand��6?   �� 5Y   &    � �� �#fe65846C   5Z   #   ��5]      �� 5^   "   " ��62   .R�5_   &   �� $��80��6-   $��25��5`   -   $ 10��5a   -   #��z��5b   -   ._�5d   *   �� $��Center=�6;   $��Center=�5e   1   5f   '   5g   #   5i      5j      5k      5l      �� 5m      $ Vertical=�6   .+�5n      �� $	��300��6   $	��200��5o      $ 10��5p      $��45,0,0,0q�5q      ��5s      �� 5t      $	 0,0&�6.   $	 1,2&�6?   .��5u      � $ #844eff��6+   $	 0.0Q�6;   � 5v      $ #ffb73a��6+   $ 1Q�6;   5w      ._�5y      � .+�5z      �� .+�5{      �� $��Add or browse
a new exam��6(   
�������$��28(�5}   $   $
��Left=�5~   $   $��
20,10,10,0q�5   $   $	��310��68   $��/Fonts/#Poppins)�5�   $   5�      �� 5�      $
��Left=�6$   $	��Top=�5�      $ 0.5,0.5&�64   $��
95,100,0,0q�6T   �� 5�       � Cursor$
 Hand��6)    �� Command 67   �� *#!DataContext.ExamEditorViewCommand+ �� " � �� TextDecorations 6�   Z� .�6�   .�5�   "   �� $��97��6(   $��75��5�   (   $��/Images/add.png��5�   (   5�      5�      5�      5�      5�      5�      5�      5�      