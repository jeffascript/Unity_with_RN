import React from 'react';

import {createStackNavigator} from '@react-navigation/stack';
import HomeScreen from './MainView';
import UnityScreen from './UnityView';

const Stack = createStackNavigator();

const MyStack = () => {
  return (
    <Stack.Navigator screenOptions={{headerShown: false}}>
      <Stack.Screen name="Home" component={HomeScreen} />
      <Stack.Screen name="UnityScreen" component={UnityScreen} />
    </Stack.Navigator>
  );
};

export default MyStack;
