package com.lab;

import javax.imageio.ImageIO;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.function.BinaryOperator;

public class Main {
    public static void main(String[] args) throws IOException {
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager entityManager = factory.createEntityManager();
        entityManager.getTransaction().begin();


        List<String> lastnames = List.of("Kowalski", "Nowak");

        //Z.4.3.1
        //Zapis ról
        List<Role> roles = new ArrayList<>();
        for(int i = 1; i < 6; i++) {
            roles.add(new Role(null, "role_" + i));
        }
        roles.forEach(entityManager::persist);

        //Z.4.3.1
        //Utworzenie listy użytkowników
        List<User> users = new ArrayList<>();
        for(int i = 1; i < 10; i++) {
            User toAdd = new User(null, "test_" + i, "test_" + i, "Andrzej", lastnames.get(i%2), i%3==0 ? User.Sex.FEMALE: User.Sex.MALE);

            //Z.4.4.4
            toAdd.addRole(roles.get(i%5));
            toAdd.addRole(roles.get((i+1)%5));
            users.add(toAdd);
        }


        //Zadanie 4.5
        BufferedImage image = ImageIO.read(new File("image.bmp"));
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "bmp", baos);
        User imageUser = new User(null, "test_image", "test_image", "Imie", "Nazwisko", User.Sex.MALE, baos.toByteArray());
        users.add(imageUser);


        //Z.4.2.3
        //Zapisanie użytkowników
        users.forEach(entityManager::persist);


        //Z.4.4.5
        //Utworzenie grup użytkowników
        UserGroup userGroup1 = new UserGroup();
        UserGroup userGroup2 = new UserGroup();
        userGroup1.addUser(users.get(0));
        userGroup1.addUser(users.get(1));
        userGroup1.addUser(users.get(2));
        userGroup2.addUser(users.get(3));
        userGroup2.addUser(users.get(4));
        userGroup2.addUser(users.get(5));
        entityManager.persist(userGroup1);
        entityManager.persist(userGroup2);


        //Z.4.3.2
        User user1 = entityManager.find(User.class, 1L);
        user1.setPassword("nowehaslo");
        entityManager.merge(user1);


        //Z.4.3.3
        User userToRemove = entityManager.find(User.class, 5L);
        entityManager.remove(userToRemove);


        entityManager.getTransaction().commit();

        //Z.4.3.4
        System.out.println("kowalscy: " + getKowalscy(entityManager)
                .stream()
                .map(User::toString)
                .reduce(" ", (s, s2) -> s + ", " + s2));

        //Z.4.3.5
        System.out.println("females: " + getFemales(entityManager)
                .stream()
                .map(User::toString)
                .reduce(" ", (s, s2) -> s + ", " + s2));

        entityManager.close();
        factory.close();
    }

    private static List<User> getKowalscy(EntityManager entityManager) {
        return entityManager.createQuery("SELECT u FROM User u WHERE u.lastName = 'Kowalski'").getResultList();
    }

    private static List<User> getFemales(EntityManager entityManager) {
        return entityManager.createQuery("SELECT u FROM User u WHERE u.sex = 'FEMALE'").getResultList();
    }
}